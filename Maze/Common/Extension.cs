// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extension.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the Extension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Some Extensions.
    /// </summary>
    public static class Extension
    {
        /// <summary>Clone a linked list</summary>
        /// <param name="listToClone">The list to clone.</param>
        /// <typeparam name="T">the list object</typeparam><returns>
        /// The cloned linked list <see cref="LinkedList{T}"/>.</returns>
        public static LinkedList<T> Clone<T>(this LinkedList<T> listToClone) where T : ICloneable
        {
            IEnumerable<T> list = listToClone.Select(item => (T)item.Clone());
            return new LinkedList<T>(list);
        }
    }
}