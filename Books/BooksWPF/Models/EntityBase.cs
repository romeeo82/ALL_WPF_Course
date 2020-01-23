namespace BooksWPF.Models
{
    public class EntityBase
    {
        private static int counter;
        public int Id { get; set; }
        public bool IsNew { get; set; }

        public EntityBase()
        {
            this.IsNew = true;
            this.Id = counter++;
        }

        /// <summary>
        /// Makes IsNew = false.
        /// </summary>
        public void Save()
        {
            this.IsNew = false;
        }
    }
}
