using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities.CustomerAggregate;
using Domain.Entities;


namespace Application.Mappings
{
    public static class MappingProfile
    {
        

        ///////////////////////////             Ingredient                ////////////////////////////////

        public static IngredientDto MappingDto(this Ingredient ingredient)
        {
            return new IngredientDto
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                IngredientSupplier = ingredient.IngredientSupplier,
                IngredientPrice = ingredient.IngredientPrice,
                IngredientQuantity = ingredient.IngredientQuantity,
                IngredientUnit = ingredient.IngredientUnit,
                IngredientType = ingredient.IngredientType
            };
        }

        public static Ingredient MappingIngredient(this IngredientDto ingredientDto)
        {
            return new Ingredient
            {
                Id = ingredientDto.Id,
                IngredientName = ingredientDto.IngredientName,
                IngredientSupplier = ingredientDto.IngredientSupplier,
                IngredientQuantity = ingredientDto.IngredientQuantity,
                IngredientPrice = ingredientDto.IngredientPrice,
                IngredientUnit = ingredientDto.IngredientUnit,
                IngredientType = ingredientDto.IngredientType
            };
        }
        public static void MappingIngredient(this IngredientDto ingredientDto, Ingredient ingredient)
        {
            ingredient.IngredientName = ingredientDto.IngredientName;
            ingredient.IngredientSupplier = ingredientDto.IngredientSupplier;
            ingredient.IngredientQuantity = ingredientDto.IngredientQuantity;
            ingredient.IngredientPrice = ingredientDto.IngredientPrice;
            ingredient.IngredientUnit = ingredientDto.IngredientUnit;
            ingredient.IngredientType = ingredientDto.IngredientType;
        }

        public static IEnumerable<IngredientDto> MappingDtos(this IEnumerable<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                yield return ingredient.MappingDto();
            }
        }

        ///////////////////////////////            Customer          ////////////////////////////////////
        public static CustomerDto MappingDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerPhoneNumber = customer.CustomerPhoneNumber,
                CustomerAddress = customer.CustomerAddress,
                CustomerEmail = customer.CustomerEmail
            };
        }

        public static Customer MappingCustomer(this CustomerDto customerDto)
        {
            return new Customer
            {
                Id = customerDto.Id,
                CustomerName = customerDto.CustomerName,
                CustomerPhoneNumber = customerDto.CustomerPhoneNumber,
                CustomerAddress = customerDto.CustomerAddress,
                CustomerEmail = customerDto.CustomerEmail
            };
        }
        public static void MappingCustomer(this CustomerDto customerDto, Customer customer)
        {
            customer.CustomerName = customerDto.CustomerName;
            customer.CustomerPhoneNumber = customerDto.CustomerPhoneNumber;
            customer.CustomerAddress = customerDto.CustomerAddress;
            customer.CustomerEmail = customerDto.CustomerEmail;
        }

        public static IEnumerable<CustomerDto> MappingDtos(this IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                yield return customer.MappingDto();
            }
        }

        public static NuocUongDto MappingDto(this NuocUong nuocUong)
        {
            return new NuocUongDto
            {
                Id = nuocUong.Id,
                TenNU = nuocUong.TenNU,
                DonGia = nuocUong.DonGia
            };
        }

        public static NuocUong MappingNuocUong(this NuocUongDto nuocUongDto)
        {
            return new NuocUong
            {
                Id = nuocUongDto.Id,
                TenNU = nuocUongDto.TenNU,
                DonGia = nuocUongDto.DonGia
            };
        }
        public static void MappingNuocUong(this NuocUongDto nuocUongDto, NuocUong nuocUong)
        {
            nuocUong.Id = nuocUongDto.Id;
            nuocUong.TenNU = nuocUongDto.TenNU;
            nuocUong.DonGia = nuocUongDto.DonGia;
        }

        public static IEnumerable<NuocUongDto> MappingDtos(this IEnumerable<NuocUong> nuocUongs)
        {
            foreach (var nuocUong in nuocUongs)
            {
                yield return nuocUong.MappingDto();
            }
        }
        
        
    }
}