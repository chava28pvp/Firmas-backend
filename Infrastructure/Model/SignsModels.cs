using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class ArchiveUrls
    {
        [Key]
        public int IdArchiveUrls { get; set; }
        public int IdSingularPoint { get; set; }
        public string PathFile { get; set; }

        public SingularPoint SingularPoint { get; set; } = null;
    }

    public class SingularPoint
    {
        [Key]
        public int IdSingularPoint { get; set; }
        public int IdTypesArchive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WiwUpload { get; set; }
        public bool Active { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime CreationDate { get; set; }

        public TypesArchive TypesArchive { get; set; } = null;
        public ICollection<ArchiveUrls> ArchiveUrls { get; set; } = new List<ArchiveUrls>();
        public ICollection<AssignedOu> AssignedOus { get; set; } = new List<AssignedOu>();
        public ICollection<AssignedPersonalizedGroup> AssignedPersonalizedGroups { get; set; } = new List<AssignedPersonalizedGroup>();
    }
    public class TypesArchive
    {
        [Key]
        public int IdTypesArchive { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<SingularPoint> SingularPoints { get; set; } = new List<SingularPoint>();
    }
    public class AssignedOu
    {
        [Key]
        public int IdAssignedOu { get; set; }
        public int IdSingularPoint { get; set; }
        public string Ou { get; set; } = string.Empty;

        public SingularPoint SingularPoint { get; set; } = null;
        public ICollection<AssignedTeam> AssignedTeams { get; set; } = new List<AssignedTeam>();
    }
    public class AssignedTeam
    {
        [Key]
        public int IdAssignedTeam { get; set; }
        public int IdAssignedOu { get; set; }
        public int Team { get; set; }

        public AssignedOu AssignedOu { get; set; } = null;
    }
    public class PersonalizedGroup
    {
        [Key]
        public int IdPersonalizedGroups { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

        public ICollection<PersonalizedGroupsOwner> Owners { get; set; } = new List<PersonalizedGroupsOwner>();
        public ICollection<PersonalizedGroupsUser> Users { get; set; } = new List<PersonalizedGroupsUser>();
        public ICollection<AssignedPersonalizedGroup> AssignedPersonalizedGroups { get; set; } = new List<AssignedPersonalizedGroup>();
    }
    public class PersonalizedGroupsOwner
    {
        [Key]
        public int IdPersonalizedGroupsOwners { get; set; }
        public int IdPersonalizedGroups { get; set; }
        public string WiwOwner { get; set; } = string.Empty;

        public PersonalizedGroup PersonalizedGroup { get; set; } = null;
    }
    public class PersonalizedGroupsUser
    {
        [Key]
        public int IdPersonalizedGroupsUsers { get; set; }
        public int IdPersonalizedGroups { get; set; }
        public string Wiw { get; set; } = string.Empty;
        public DateTime LoadDate { get; set; }

        public PersonalizedGroup PersonalizedGroup { get; set; } = null;
    }
    public class AssignedPersonalizedGroup
    {
        [Key]
        public int IdAssignedPersonalizedGroups { get; set; }
        public int IdSingularPoint { get; set; }
        public int IdPersonalizedGroups { get; set; }

        public SingularPoint SingularPoint { get; set; } = null;
        public PersonalizedGroup PersonalizedGroup { get; set; } = null;
    }
    public class RelationsSign
    {
        [Key]
        public int IdRelationsSigns { get; set; }
        public int IdAssignedAny { get; set; }
        public int IdTypesSigns { get; set; }

        public TypesSign TypesSign { get; set; } = null;
        public ICollection<Sign> Signs { get; set; } = new List<Sign>();
    }
    public class TypesSign
    {
        [Key]
        public int IdTypesSigns { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<RelationsSign> RelationsSigns { get; set; } = new List<RelationsSign>();
    }
    public class Sign
    {
        [Key]
        public int IdSign { get; set; }
        public int IdRelationsSigns { get; set; }
        public string WiwSign { get; set; } = string.Empty;
        public bool IsSignBadge { get; set; }
        public DateTime SignDate { get; set; }

        public RelationsSign RelationsSign { get; set; } = null;
    }


}
