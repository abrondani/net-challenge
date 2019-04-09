<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="173b7fc0-8326-4859-ae91-8c8c4a2814a9" namespace="StockServiceLibrary" xmlSchemaNamespace="urn:StockServiceLibrary" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="ServiceConfigurationSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="serviceConfigurationSection">
      <attributeProperties>
        <attributeProperty name="RabbitMQ_HostName" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="rabbitMQ_HostName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/173b7fc0-8326-4859-ae91-8c8c4a2814a9/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationSection>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>