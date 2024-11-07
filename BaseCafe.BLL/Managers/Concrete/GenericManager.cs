using AutoMapper;
using BaseCafe.BLL.Managers.Abstract;
using BaseCafe.DAL.Entities.BaseClass;
using BaseCafe.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCafe.BLL.Managers.Concrete
{   /// <summary>
    /// DTO ve entity üzerinde işelmlerin gerçekleştiği sınıf
    /// </summary>

    public  class GenericManager<TDTO, TEntity> : IGenericManager<TDTO, TEntity> where TEntity : BaseEntity, new() where TDTO : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        public GenericManager(IRepository<TEntity> repository)
        {
            //mapper dto ve entity nesneleri arasında dönüşüm yapmmamızı sağlar
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TDTO, TEntity>().ReverseMap());
            _mapper = new Mapper(config);
            _repository = repository;
        }
        /// <summary>
        /// yeni bir sto nesnesi ekler ve eklenen nesneyi döner
        /// </summary>
        /// <param name="dTO">Eklenecek DTO nesnesi .</param>
        /// <returns>Eklenen DTO nesnesi</returns>
        public TDTO Add(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity>(dTO);
            var newEntity = _repository.Add(entity);
            TDTO newDto = _mapper.Map<TDTO>(newEntity);
            return newDto;
        }
        /// <summary>
        /// bir liste hlainde DTO nesnelerini ekler ve eklenen listeyi deöner
        /// </summary>
        /// <param name="dTOs">Eklenecek DTO nesnelerinin listesi</param>
        /// <returns></returns>
        public List<TDTO> AddRange(List<TDTO> dTOs)
        {
            List<TEntity> entities = _mapper.Map<List<TEntity>>(dTOs);
            _repository.AddRange(entities);
            return dTOs;
        }
        /// <summary>
        /// belitirlen DTO nesnesini siler 
        /// </summary>

        public TDTO Delete(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity>(dTO);
            _repository.Delete(entity);
            return dTO;
        }
        /// <summary>
        /// belirtilen kimliğe göre bir DTO nesnesini bulur ve döner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TDTO Find(int id)
        {
            var entity = _repository.Find(id);
            var DTO = _mapper.Map<TDTO>(entity);
            return DTO;
        }
        /// <summary>
        /// belirtilen koşıula göre dto nesnesi getirir
        /// </summary>
        /// <param name="predicate">dto nesnesinn filtreleme ifadesi</param>
        /// <returns></returns>
        public TDTO Get(Expression<Func<TDTO, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entity = _repository.Get(entityPredicate);
            var DTO = _mapper.Map<TDTO>(entity);
            return DTO;
        }

        /// <summary>
        /// Tüm DTO nesnelerinin listesini döner
        /// </summary>
        /// <returns></returns>
        public IList<TDTO> GetAll()
        {
            var entities = _repository.GetAll();
            var DTOs = _mapper.Map<List<TDTO>>(entities);
            return DTOs;
        }
        /// <summary>
        /// belirtilen dto nesnesini kaldırır ve kaldırlan nesnesyi döner.
        /// </summary>
        /// <param name="dTO"></param>
        /// <returns></returns>
        public TDTO Remove(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity>(dTO);
            _repository.Remove(entity);
            return dTO;
        }
        /// <summary>
        /// belirtilen DTO nesnesini günceler ve güncellenmiş nesneyi döner.
        /// </summary>
        
        public TDTO Update(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity>(dTO);
            _repository.Update(entity);
            return dTO; 
        }
    }
}
