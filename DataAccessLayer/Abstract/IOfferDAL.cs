
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IOfferDAL:IGenericDAL<Offer>
	{
		List<Offer> GetOffers(Guid id);
	}
}
