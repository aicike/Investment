using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class CompanyRelationModel : BaseModel<CompanyRelation>
    {
        public List<CompanyRelation> GetByRelationObjectID(int RelationObjectID)
        {
            return List().Where(a => a.RelationObjectID == RelationObjectID).ToList();
        }

        //public new Result Add(CompanyRelation cr)
        //{
        //    return null;
        //}
    }
}
