using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class ProductCode
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The product or service code.
        /// </value>
        [Key]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The product or description.
        /// </value>
        public string Description { get; set; }
    }
}
