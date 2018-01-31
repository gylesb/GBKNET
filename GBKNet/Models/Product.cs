using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBKNet.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
    }

    public override bool Equals(System.Object otherProduct)
    {
        if (!(otherProduct is Product))
        {
            return false;
        }
        else
        {
            Product newProduct = (Product)otherProduct;
            return this.ProductId.Equals(newProduct.ProductId);
        }
    }

    public override int GetHashCode()
    {
        return this.ProductId.GetHashCode();
    }

    public double GetAverageRating()
    {

        double counter = 0;
        double totalRating = 0;

        foreach (var review in Reviews)
        {
            totalRating = totalRating + review.Rating;
            counter++;
        }

        double result = totalRating / counter;


        return Math.Ceiling(result);

    }