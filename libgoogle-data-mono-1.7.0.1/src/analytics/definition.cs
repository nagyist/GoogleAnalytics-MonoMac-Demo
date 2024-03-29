/* Copyright (c) 2010 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/


using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Analytics;
using Google.GData.Extensions;
using Google.GData.Client;


namespace Google.GData.Analytics
{
  public class Definition : SimpleElement
  {

    public Definition() : base(AnalyticsNameTable.XmlDefinitionElement,
                               AnalyticsNameTable.gAnalyticsPrefix,
                               AnalyticsNameTable.gAnalyticsNamspace)
    {
      //this.Attributes.Add(BaseNameTable.XmlName, null);
      this.Attributes.Add(AnalyticsNameTable.XmlAttributeId, null); 
    }


    public Definition(String value) : base(AnalyticsNameTable.XmlDefinitionElement,
                                           AnalyticsNameTable.gAnalyticsPrefix,
                                           AnalyticsNameTable.gAnalyticsNamspace, value)
    {
    }
  }
}

