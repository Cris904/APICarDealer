using CarDealershipAPI.Models;
using CarDealershipAPI.Repositories.Interfaces;
using CarDealershipAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipAPI.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task AddCustomer(Customer customer)
        {
            await _customerRepository.Add(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.Update(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.Delete(id);
        }
    }
}
