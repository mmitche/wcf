// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace System.ServiceModel.Description
{
    [XmlRoot(ElementName = MetadataStrings.MetadataExchangeStrings.Location, Namespace = MetadataStrings.MetadataExchangeStrings.Namespace)]
    public class MetadataLocation
    {
        private string _location;

        public MetadataLocation()
        {
        }

        public MetadataLocation(string location)
        {
            this.Location = location;
        }

        [XmlText]
        public string Location
        {
            get { return _location; }
            set
            {
                if (value != null)
                {
                    Uri uri;
                    if (!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out uri))
                        throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(SR.Format(SR.SFxMetadataReferenceInvalidLocation, value));
                }

                _location = value;
            }
        }
    }
}
