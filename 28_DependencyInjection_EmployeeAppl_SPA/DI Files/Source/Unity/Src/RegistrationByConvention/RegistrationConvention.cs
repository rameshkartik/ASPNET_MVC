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

namespace Microsoft.Practices.Unity
{
    /// <summary>
    /// Represents a set of types to register and their registration settings.
    /// </summary>
    public abstract class RegistrationConvention
    {
        /// <summary>
        /// Gets types to register.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
        public abstract IEnumerable<Type> GetTypes();

        /// <summary>
        /// Gets a function to get the types that will be requested for each type to configure.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
        public abstract Func<Type, IEnumerable<Type>> GetFromTypes();

        /// <summary>
        /// Gets a function to get the name to use for the registration of each type.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
        public abstract Func<Type, string> GetName();

        /// <summary>
        /// Gets a function to get the <see cref="LifetimeManager"/> for the registration of each type. Defaults to no lifetime management.
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
        public abstract Func<Type, LifetimeManager> GetLifetimeManager();

        /// <summary>
        /// Gets a function to get the additional <see cref="InjectionMember"/> objects for the registration of each type. Defaults to no injection members.
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Could require computations")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public abstract Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers();
    }
}
