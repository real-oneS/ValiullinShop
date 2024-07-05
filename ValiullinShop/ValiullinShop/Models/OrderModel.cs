namespace ValiullinShop.Models
{
	public class OrderModel
	{
		public OrderModel(string firstname, string lastname, string middlename, string phone, string email, string address, string paymentMethod)
		{
			FirstName = firstname;
			LastName = lastname;
			MiddleName = middlename;
			Phone = phone;
			Email = email;
			Address = address;
			PaymentMethod = paymentMethod;
		}

		public string FirstName {get;set;}
		public string LastName { get;set;}
		public string MiddleName { get;set;}
		public string Phone { get;set;}
		public string Email { get;set;}
		public string Address { get;set;}
		public string PaymentMethod { get;set;}
		
	}
}
