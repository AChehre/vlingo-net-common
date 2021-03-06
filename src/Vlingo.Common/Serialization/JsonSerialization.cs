﻿// Copyright (c) 2012-2018 Vaughn Vernon. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Vlingo.Common.Serialization
{
    public static class JsonSerialization
    {
        private static readonly JsonConverter DateTimeConverter = new IsoDateTimeConverter();

        private static string Serialize(object value) => JsonConvert.SerializeObject(value, DateTimeConverter);

        public static T Deserialized<T>(string serialization)
            => JsonConvert.DeserializeObject<T>(serialization, DateTimeConverter);

        public static List<T> DeserializedList<T>(string serialization)
            => JsonConvert.DeserializeObject<List<T>>(serialization, DateTimeConverter);

        public static string Serialized(object instance)
            => JsonConvert.SerializeObject(instance, DateTimeConverter);
    }
}
