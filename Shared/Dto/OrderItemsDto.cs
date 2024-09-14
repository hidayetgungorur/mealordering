using System;
namespace MealOrdering.Shared.Dto
{
	public class OrderItemsDto
	{
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid CreatedUserId { get; set; }

        public Guid OrderId { get; set; }

        public String Description { get; set; }


        public String CreatedUserFullName { get; set; }

        public String OrderName { get; set; }
    }
}

