﻿//-----------------------------------------------------------------------
// <copyright file="JsonArrayParser.cs" company="Akvelon">
//     Copyright (c) Akvelon. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AkvelonContacts.Common
{
    /// <summary>
    /// Parses JSON to Custom class.
    /// </summary>
    /// <typeparam name="T">Class custom object.</typeparam>
    public abstract class JsonArrayParser<T>
    {
        /// <summary>
        /// Gets the  <see cref="JsonArrayParser{T}"/> list from JSON string.
        /// </summary>
        /// <param name="json">JSON string.</param>
        /// <returns>Contacts list</returns>
        public List<T> GetListFromJsonArray(string json)
        {
            List<T> objectList = new List<T>();
            var ja = JArray.Parse(json);

            foreach (JObject jo in ja)
            {
                T c = this.ConvertJObjectToCustomType(jo);
                objectList.Add(c);
            }

            return objectList;
        }

        /// <summary>
        /// Converts JObject to <see cref="{T}"/>.
        /// </summary>
        /// <param name="jo">JObject with contact data.</param>
        /// <returns>Convert contact.</returns>
        public abstract T ConvertJObjectToCustomType(JObject jo);
    }
}
