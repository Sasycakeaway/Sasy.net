namespace SvelteKitSample.Model
{
    public partial class Newsletter
    {
        public string FkEmail { get; set; } = null!;
        public Guid PkToken { get; set; }
    }
}
