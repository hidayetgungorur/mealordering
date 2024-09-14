using System;
namespace MealOrdering.Shared.Dto
{
	public class SupplierDto
	{
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public String Name { get; set; }

        public String WebURL { get; set; }

        public bool IsActive { get; set; }
    }
}

