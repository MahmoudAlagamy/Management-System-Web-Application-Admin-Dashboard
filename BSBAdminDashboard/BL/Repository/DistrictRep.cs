﻿using BSBAdminDashboard.BL.Interface;
using BSBAdminDashboard.DAL.Database;
using BSBAdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSBAdminDashboard.BL.Repository
{
    public class DistrictRep : IDistrictRep
    {
        //private DbContainer db = new DbContainer();

        private readonly DbContainer db;

        public DistrictRep(DbContainer db)
        {
            this.db = db;
        }

        public IQueryable<DistrictVM> Get()
        {
            IQueryable<DistrictVM> data = GetAllDistrict();

            return data;
        }

        public DistrictVM GetById(int id)
        {
            DistrictVM data = GetDistrictById(id);
            // FirstOrDefault couse if not found id back null
            return data;
        }

        // Refactor

        private DistrictVM GetDistrictById(int id)
        {
            return db.District.Where(a => a.Id == id)
                                    .Select(a => new DistrictVM
                                    {
                                        Id = a.Id,
                                        DistrictName = a.DistrictName,
                                        CityId = a.CityId
                                    }).FirstOrDefault();
        }

        private IQueryable<DistrictVM> GetAllDistrict()
        {
            return db.District.Select(a => new DistrictVM
            {
                Id = a.Id,
                DistrictName = a.DistrictName,
                CityId = a.CityId
            });
        }
    }
}
