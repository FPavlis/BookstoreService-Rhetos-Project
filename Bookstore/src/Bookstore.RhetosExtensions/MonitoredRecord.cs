using System.Collections.Generic;
using System.ComponentModel.Composition;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Utilities;

namespace Bookstore.RhetosExtensions
{
    /// <summary>
    /// CodeTable is a custom DSL concept that generates the following 4 DSL statements on an entity:
    /// <code>
    /// ShortString Code { AutoCode; }
    /// ShortString Name { Required; }
    /// </code> 
    /// </summary>
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("MonitoredRecord")]
    public class MonitoredRecordInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }
    }

    [Export(typeof(IConceptMacro))]
    public class MonitoredRecordMacro : IConceptMacro<MonitoredRecordInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(MonitoredRecordInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            var createdAt = new DateTimePropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "CreatedAt"
            };
            newConcepts.Add(createdAt);

            newConcepts.Add(new CreationTimeInfo
            {
                Property = createdAt
            });

            newConcepts.Add(new DenyUserEditPropertyInfo
            {
                Property = createdAt
            });

            var logging = new EntityLoggingInfo {Entity = conceptInfo.Entity};
            newConcepts.Add(logging);

            newConcepts.Add(new AllPropertiesLoggingInfo{EntityLogging = logging});

            return newConcepts;
        }
    }
}