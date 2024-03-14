using System;
using AutoMapper;
using Entites;
using EquipeDTO;

namespace Services.MapperConfig
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{
            CreateMap<JoueurEntity, JoueurDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.NomJoueur, opt => opt.MapFrom(entity => entity.NomJoueur))
                .ForMember(dto => dto.PrenomJoueur, opt => opt.MapFrom(entity => entity.PrenomJoueur))
                .ForMember(dto => dto.equipeFK, opt => opt.MapFrom(entity => entity.EquipeForeignKey));

            CreateMap<JoueurEntity, JoueurDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.NomJoueur, opt => opt.MapFrom(entity => entity.NomJoueur))
                .ForMember(dto => dto.PrenomJoueur, opt => opt.MapFrom(entity => entity.PrenomJoueur))
                .ForMember(dto => dto.equipeFK, opt => opt.MapFrom(entity => entity.EquipeForeignKey)).ReverseMap();
            CreateMap<EquipeEntity, EquipeDTO.EquipeDTO>()
                     .ForMember(dest => dest.idJoueur, opt =>
                        opt.MapFrom(src => src.Joueurs.Select(x => x.Id))
                        );

            CreateMap<EquipeEntity, EquipeDTO.EquipeDTO>()
                   .ForMember(dest => dest.idJoueur, opt =>
                      opt.MapFrom(src => src.Joueurs.Select(x => x.Id))
                      ).ReverseMap();


            /*        CreateMap<EquipeEntity, EquipeDTO.EquipeDTO>()
                        .ForMember(dest => dest.joueurDTOs, opt => opt.MapFrom(src => src.Joueurs.Select(m=>m.Id)));
                    CreateMap<EquipeDTO.EquipeDTO, EquipeEntity>()
                        .ForMember(dest => dest.Joueurs, opt => opt.MapFrom(src => src.joueurDTOs.Select(m => m.Id))).ReverseMap();
            */

            /*        CreateMap<EquipeDTO.EquipeDTO, EquipeEntity>()
                    .ForMember(entity => entity.Joueurs, opt => opt.MapFrom(model => model.joueurDTOs))
                    .AfterMap((model, entity) =>
                    {
                    foreach (var entityUserAndTag in entity.Joueurs)
                    {
                        entityUserAndTag.EquipeEntity = entity;
                    }
                    });


                    CreateMap<EquipeDTO.EquipeDTO, EquipeEntity>()
                    .ForMember(entity => entity.Joueurs, opt => opt.MapFrom(model => model.joueurDTOs))
                    .AfterMap((model, entity) =>
                               {
                                   foreach (var entityUserAndTag in entity.Joueurs)
                                   {
                                       entityUserAndTag.EquipeEntity = entity;
                                   }
                    }).ReverseMap();*/

        }
	}
}

