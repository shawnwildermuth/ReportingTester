using AutoMapper;
using ReportingTester.Data.Entities;
using ReportingTester.Models;

namespace ReportingTester.Data;

public class StoreProfile : Profile
{
	public StoreProfile()
	{
		CreateMap<Customer, CustomerModel>().ReverseMap();
    CreateMap<Order, OrderModel>().ReverseMap();
    CreateMap<OrderItem, OrderItemModel>().ReverseMap();
    CreateMap<Product, ProductModel>().ReverseMap();
    CreateMap<Store, StoreModel>().ReverseMap();
    CreateMap<Staff, StaffModel>().ReverseMap();
  }
}