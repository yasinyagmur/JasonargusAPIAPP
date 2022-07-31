using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace JasonAPI
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class ArgusUser
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string FirstName { get; set; } = String.Empty;
        [StringLength(500)]

        public string LastName { get; set; } = String.Empty!;
        [StringLength(300)]

        public string Email { get; set; } = String.Empty!;
        [StringLength(500)]

        public int? Age { get; set; }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
