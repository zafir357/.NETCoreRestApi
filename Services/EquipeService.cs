using System;
using AutoMapper;
using Services.Interface;
using Repository;
using Mapper;
using ModelEquipe;

namespace Services
{
	public class EquipeService:IEquipeService
	{
        private readonly IEquipeRepository _equipeRepository;
        private readonly IMapper _mapper;

        public EquipeService(IEquipeRepository equipeRepository, IMapper mapper)
        {
            _equipeRepository = equipeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EquipeDTO.EquipeDTO> GetAll()
        {
            var list = new List<EquipeDTO.EquipeDTO>();
            foreach (var item in _equipeRepository.GetAll())
                list.Add(_mapper.Map<EquipeDTO.EquipeDTO>(item));
            return list;
        }

        /*public EquipeDTO.EquipeDTO GetById(int id)
        {

            var data = _equipeRepository.GetById(id);
            return _mapper.Map<EquipeDTO.EquipeDTO>(data);
        }*/

        public dynamic GetJoueurByEquipe(int id, int joueurId)
        {

            dynamic data = _equipeRepository.GetJoueurEquipeById(id,joueurId);
            return _mapper.Map<EquipeDTO.JoueurDTO>(data[0]);
        }


        public void Create(EquipeDTO.EquipeDTO equipeDTO)
        {
            _equipeRepository.Create(_mapper.Map<Entites.EquipeEntity>(equipeDTO));
           

        }

        public void Update(EquipeDTO.EquipeDTO equipeDTO, int id)
        {
            if (equipeDTO != null)
            {
                var equipe = _equipeRepository.GetById(id);
                if (equipe != null)
                {
                  _equipeRepository.Update(_mapper.Map<Entites.EquipeEntity>(equipeDTO),id);
                   
                }
            }


            
        }

        public void Delete(EquipeDTO.EquipeDTO equipeDTO)
        {
            _equipeRepository.Delete(_mapper.Map<Entites.EquipeEntity>(equipeDTO));
        }

        public EquipeDTO.EquipeDTO GetById(int id)
        {
            var data = _equipeRepository.GetById(id);
            return _mapper.Map<EquipeDTO.EquipeDTO>(data);
        }
    }
}

