namespace Raunstrup.Core.Domain
{
    public class Project
    {
        private Draft _draft;

        public Project(Draft draft)
        {
            _draft = draft;
        }

        public Draft GetDraft()
        {
            return _draft;
        }
    }
}
