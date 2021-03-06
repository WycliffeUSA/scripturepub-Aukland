using ScripturePublishingEntity.Entities;

namespace ScripturePublishingEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkflowEngine : DbContext
    {
        public WorkflowEngine()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<ProcessStep> ProcessSteps { get; set; }
        public virtual DbSet<ProcessStepOrder> ProcessStepOrders { get; set; }
        public virtual DbSet<ResultType> ResultTypes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<ActionType> ActionTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
