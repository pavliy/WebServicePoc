﻿using DomainModel;

using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            this.Table("Projects");

            this.Id(i => i.Id).Not.Nullable().GeneratedBy.Assigned();

            this.Map(i => i.Name).Not.Nullable().Length(255);

            this.HasMany<ProjectItem>(i => i.Items)
                .Cascade.AllDeleteOrphan()
                .Access.CamelCaseField()
                .NotFound.Exception()
                .Fetch.Join()
                .AsBag()
                .Inverse();

            this.Version(i => i.RootRevision).UnsavedValue("0");

            this.DynamicUpdate();
        }
    }
}