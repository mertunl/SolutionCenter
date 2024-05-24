
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IOfferService:IGenericService<Offer>
	{
		List<Offer> GetOffer(Guid id);
		//List<Offer>  Update(Offer offer);
	}
}
