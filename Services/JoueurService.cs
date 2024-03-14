using System;
using AutoMapper;
using EquipeDTO;
using Repository;
using Services.Interface;

namespace Services
{
    public class JoueurService : IJoueurService
    {

        private readonly IJoueurRepository _joueurRepository;
        private readonly IMapper _mapper;

        public JoueurService(IJoueurRepository joueurRepository, IMapper mapper)
        {

            _joueurRepository = joueurRepository;
            _mapper = mapper;
        }

        public IEnumerable<JoueurDTO> GetAll()
        {
            var list = new List<JoueurDTO>();
            foreach (var item in _joueurRepository.GetAll())
                list.Add(_mapper.Map<JoueurDTO>(item));
            return list;
        }

        public JoueurDTO GetById(int id)
        {

            var data = _joueurRepository.GetById(id);
            return _mapper.Map<JoueurDTO>(data);
        }

        public void Create(JoueurDTO joueurDTO)
        {
            _joueurRepository.Create(_mapper.Map<Entites.JoueurEntity>(joueurDTO));
           
        }

        public void Update(JoueurDTO joueurDTO,int id)
        {

            _joueurRepository.Update(_mapper.Map<Entites.JoueurEntity>(joueurDTO),id);
           
        }

        public void Delete(JoueurDTO joueurDTO)
        {
            _joueurRepository.Delete(_mapper.Map<Entites.JoueurEntity>(joueurDTO));
        }
    }
}

