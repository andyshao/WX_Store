﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using IBaseService;
using Fish_IRepository;
namespace Fish_Service
{
    /// <summary>
    /// 用户评价    BLL层
    /// </summary>
    public class ProductReviewService:BaseService<ProductReview>,IProductReviewService
    {
        public ProductReviewService(IBaseRepository<ProductReview> baseRepository) : base(baseRepository)
        {

        }
    }
}
