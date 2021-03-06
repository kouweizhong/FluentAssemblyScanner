﻿using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace FluentAssemblyScanner
{
    public class BasedOnDefiner : BasedOnDefinerBase
    {
        private readonly FromAssemblyDefinerBase _fromAssemblyDefinerBase;

        internal BasedOnDefiner([NotNull] IEnumerable<Type> basedOns, [NotNull] FromAssemblyDefinerBase fromAssemblyDefinerBase)
            : base(basedOns)
        {
            _fromAssemblyDefinerBase = fromAssemblyDefinerBase;
        }

        /// <summary>
        ///     Filters this instance.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public FilterDefiner Filter()
        {
            return new FilterDefiner(
                _fromAssemblyDefinerBase.GetAllTypes().ToList(),
                new List<Func<Type, bool>>
                {
                    type => BasedOns.Any(t => t.IsAssignableFrom(type)),
                    type => TypeFilter.ApplyTo(type)
                });
        }

        /// <summary>
        ///     Determines whether this instance has attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner HasAttribute<TAttribute>() where TAttribute : Attribute
        {
            Where(ComponentExtensions.HasAttribute<TAttribute>);
            return this;
        }

        /// <summary>
        ///     Determines whether the specified attribute type has attribute.
        /// </summary>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner HasAttribute([NotNull] Type attributeType)
        {
            Where(type => ComponentExtensions.HasAttribute(type, attributeType));
            return this;
        }

        /// <summary>
        ///     Ins the namespace.
        /// </summary>
        /// <param name="namespace">The namespace.</param>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner InNamespace([NotNull] string @namespace)
        {
            return Where(ComponentExtensions.IsInNamespace(@namespace, false));
        }

        /// <summary>
        ///     Ins the namespace.
        /// </summary>
        /// <param name="namespace">The namespace.</param>
        /// <param name="includeSubnamespaces">if set to <c>true</c> [include subnamespaces].</param>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner InNamespace([NotNull] string @namespace, bool includeSubnamespaces)
        {
            return Where(ComponentExtensions.IsInNamespace(@namespace, includeSubnamespaces));
        }

        /// <summary>
        ///     Ins the same namespace of.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner InSameNamespaceOf([NotNull] Type type)
        {
            return Where(ComponentExtensions.IsInSameNamespaceOf(type));
        }

        /// <summary>
        ///     Ins the same namespace of.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeSubnamespaces">if set to <c>true</c> [include subnamespaces].</param>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner InSameNamespaceOf([NotNull] Type type, bool includeSubnamespaces)
        {
            return Where(ComponentExtensions.IsInSameNamespaceOf(type, includeSubnamespaces));
        }

        /// <summary>
        ///     Ins the same namespace of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner InSameNamespaceOf<T>()
        {
            return Where(ComponentExtensions.IsInSameNamespaceOf<T>());
        }

        /// <summary>
        ///     Ins the same namespace of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includeSubnamespaces">if set to <c>true</c> [include subnamespaces].</param>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner InSameNamespaceOf<T>(bool includeSubnamespaces) where T : class
        {
            return Where(ComponentExtensions.IsInSameNamespaceOf<T>(includeSubnamespaces));
        }

        /// <summary>
        ///     Ors the based on.
        /// </summary>
        /// <param name="basedOn">The based on.</param>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner OrBasedOn([NotNull] Type basedOn)
        {
            BasedOns.Add(basedOn);
            return this;
        }

        /// <summary>
        ///     Ors the based on.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [NotNull]
        public BasedOnDefiner OrBasedOn<T>()
        {
            BasedOns.Add(typeof(T));
            return this;
        }

        /// <summary>
        ///     Wheres the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        [NotNull]
        protected BasedOnDefiner Where([NotNull] Predicate<Type> filter)
        {
            return If(filter).As<BasedOnDefiner>();
        }
    }
}
