using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public static class RawSql
    {
        public static async Task<bool> UpdateManyToManyAsync(this MyContext _context, string tableName, string idParentName, string idChildName, int idParent, List<int> ids)
        {
            if (ids == null )
            {
                return false;
            }
            try
            {
                await _context.Database.OpenConnectionAsync();
                
                var req = $@"DELETE FROM {tableName} WHERE  {idParentName} = {idParent}";
                await _context.Database.ExecuteSqlRawAsync(req);

                ids.ForEach(idChild => {
                    _context.Database.ExecuteSqlRaw($@"INSERT INTO {tableName} ({idParentName}, {idChildName}) VALUES ({idParent}, {idChild}) ");
                });

                await _context.Database.CloseConnectionAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

         public static bool UpdateManyToMany(this MyContext _context, string tableName, string idParentName, string idChildName, int idParent, List<int> ids)
        {
            if (ids == null )
            {
                return false;
            }
            try
            {
                _context.Database.OpenConnection();

                ids.ForEach(idChild => {
                    _context.Database.ExecuteSqlRaw($@"INSERT INTO {tableName} ({idParentName}, {idChildName}) VALUES ({idParent}, {idChild}) ");
                });

                _context.Database.CloseConnection();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public static bool DeleteInsertManyToMany(this MyContext _context, string tableName, string idParentName, string idChildName, int idParent, List<int> ids)
        {
            if (ids == null )
            {
                return false;
            }
            try
            {
                _context.Database.OpenConnection();
                
                var req = $@"DELETE FROM {tableName} WHERE  {idParentName} = {idParent}";
                _context.Database.ExecuteSqlRaw(req);

                ids.ForEach(idChild => {
                    _context.Database.ExecuteSqlRaw($@"INSERT INTO {tableName} ({idParentName}, {idChildName}) VALUES ({idParent}, {idChild}) ");
                });

                _context.Database.CloseConnection();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public static async Task<bool> DeleteManyToManyAsync(this MyContext _context, string tableName, string idParentName, int idParent)
        {
            try
            {
                await _context.Database.OpenConnectionAsync();

                var req = $@"DELETE FROM {tableName} WHERE  {idParentName} = {idParent}";
                await _context.Database.ExecuteSqlRawAsync(req);

                await _context.Database.CloseConnectionAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public static bool DeleteManyToMany(this MyContext _context, string tableName, string idParentName, int idParent)
        {
            try
            {
                _context.Database.OpenConnection();

                var req = $@"DELETE FROM {tableName} WHERE  {idParentName} = {idParent}";
                _context.Database.ExecuteSqlRaw(req);

                _context.Database.CloseConnection();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }
        

        // public static async Task<bool> AddPostCustomerAsync(this MyContext _context, CustomerProduct model, string tableName = "CustomerProducts")
        // {
        //     try
        //     {
        //         _context.Database.OpenConnectionAsync();

        //         var req = $@"INSERT INTO {tableName} (CustomersId, ProductsId) VALUES ({model.CustomersId}, {model.ProductsId})";
        //         await _context.Database.ExecuteSqlRawAsync(req);

        //         await _context.Database.CloseConnectionAsync();

        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //     }

        //     return true;
        // }
    }

    // public class CustomerProduct {
    //     public int CustomersId {get; set;}
    //     public int ProductsId {get; set;}
    // }
}