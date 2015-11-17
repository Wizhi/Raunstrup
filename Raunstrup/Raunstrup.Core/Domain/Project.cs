namespace Raunstrup.Core.Domain
{
    public class Project
    {
        private Draft draft;

        public Project(Draft draft)
        {
            this.draft = draft;
        }

        public Draft GetDraft()
        {
            return draft;
        }
    }
}
