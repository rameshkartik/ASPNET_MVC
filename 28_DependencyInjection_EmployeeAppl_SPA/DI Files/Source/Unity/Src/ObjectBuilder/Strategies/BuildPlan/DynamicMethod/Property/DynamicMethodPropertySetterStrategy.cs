﻿//===============================================================================
// Microsoft patterns & practices
// Unity Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2
{
    /// <summary>
    /// A <see cref="BuilderStrategy"/> that generates IL to resolve properties
    /// on an object being built.
    /// </summary>
    public class DynamicMethodPropertySetterStrategy : BuilderStrategy
    {
        private static readonly MethodInfo setCurrentOperationToResolvingPropertyValue =
            StaticReflection.GetMethodInfo(() => SetCurrentOperationToResolvingPropertyValue(null, null));

        private static readonly MethodInfo setCurrentOperationToSettingProperty =
            StaticReflection.GetMethodInfo(() => SetCurrentOperationToSettingProperty(null, null));

        /// <summary>
        /// Called during the chain of responsibility for a build operation.
        /// </summary>
        /// <param name="context">The context for the operation.</param>
        public override void PreBuildUp(IBuilderContext context)
        {
            Guard.ArgumentNotNull(context, "context");
            DynamicBuildPlanGenerationContext dynamicBuildContext = (DynamicBuildPlanGenerationContext)(context.Existing);

            IPolicyList resolverPolicyDestination;
            IPropertySelectorPolicy selector = context.Policies.Get<IPropertySelectorPolicy>(context.BuildKey, out resolverPolicyDestination);

            bool shouldClearOperation = false;

            foreach (SelectedProperty property in selector.SelectProperties(context, resolverPolicyDestination))
            {
                shouldClearOperation = true;

                ParameterExpression resolvedObjectParameter = Expression.Parameter(property.Property.PropertyType);

                dynamicBuildContext.AddToBuildPlan(
                    Expression.Block(
                        new ParameterExpression[] { resolvedObjectParameter },
                        Expression.Call(
                                    null, 
                                    setCurrentOperationToResolvingPropertyValue,
                                    Expression.Constant(property.Property.Name),
                                    dynamicBuildContext.ContextParameter),
                        Expression.Assign(
                                resolvedObjectParameter,
                                dynamicBuildContext.GetResolveDependencyExpression(property.Property.PropertyType, property.Key)),
                        Expression.Call(
                                    null,
                                    setCurrentOperationToSettingProperty,
                                    Expression.Constant(property.Property.Name),
                                    dynamicBuildContext.ContextParameter),
                        Expression.Call(
                            Expression.Convert(dynamicBuildContext.GetExistingObjectExpression(), dynamicBuildContext.TypeToBuild ),
                            GetValidatedPropertySetter(property.Property),
                            resolvedObjectParameter)
                        ));
            }

            // Clear the current operation
            if (shouldClearOperation)
            {
                dynamicBuildContext.AddToBuildPlan(dynamicBuildContext.GetClearCurrentOperationExpression());
            }
        }

        private static MethodInfo GetValidatedPropertySetter(PropertyInfo property)
        {
            //todo: Added a check for private to meet original expectations; we could consider opening this up for 
            //      private property injection.
            var setter = property.SetMethod;
            if(setter == null || setter.IsPrivate)
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.CurrentCulture,
                        Resources.PropertyNotSettable,
                        property.Name, property.DeclaringType.FullName)
                    );
            }
            return setter;
        }

        /// <summary>
        /// A helper method used by the generated IL to store the current operation in the build context.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Validation done by Guard class.")]
        public static void SetCurrentOperationToResolvingPropertyValue(string propertyName, IBuilderContext context)
        {
            Guard.ArgumentNotNull(context, "context");
            context.CurrentOperation = new ResolvingPropertyValueOperation(
                context.BuildKey.Type, propertyName);
        }

        /// <summary>
        /// A helper method used by the generated IL to store the current operation in the build context.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Validation done by Guard class.")]
        public static void SetCurrentOperationToSettingProperty(string propertyName, IBuilderContext context)
        {
            Guard.ArgumentNotNull(context, "context");

            context.CurrentOperation = new SettingPropertyOperation(
                context.BuildKey.Type, propertyName);
        }
    }
}
