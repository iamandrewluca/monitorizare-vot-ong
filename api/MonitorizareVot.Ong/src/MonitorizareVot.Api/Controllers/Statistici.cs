﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MonitorizareVot.Ong.Api.Extensions;
using MonitorizareVot.Ong.Api.Filters;
using MonitorizareVot.Ong.Api.ViewModels;

namespace MonitorizareVot.Ong.Api.Controllers
{
    [Route("api/v1/statistici")]
    [ValidateModelState]
    public class Statistici : Controller
    {
        private readonly IMediator _mediator;

        public Statistici(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returneaza topul judetelor in functie de numarul de observatori
        /// </summary>
        /// <param name="model">Detaliile de paginare</param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> NumarObservatori(PagingModel model)
        {
            return await _mediator.SendAsync(new StatisticiNumarObservatoriQuery
            {
                PageSize = model.PageSize,
                Page = model.Page
            });
        }

        /// <summary>
        /// Returneaza topul judetelor sau sectiilor in functie de numarul de sesizari
        /// </summary>
        /// <param name="model">  Detaliile de paginare (default Page=1, PageSize=5)
        /// Grupare (0 - Judet | 1 - Sectie)
        /// Formular (codul formularulu care va fi luat in calcul pentru statistci - "" (string.Empty) inseamna toate)
        /// </param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> Sesizari(FiltruStatisticiSimple model)
        {
            return await _mediator.SendAsync(new StatisticiTopSesizariQuery
            {
                Grupare = model.Grupare,
                Formular = model.Formular,
                Page = model.Page == 0 ? 1 : model.Page,
                PageSize = model.PageSize == 0 ? 5 : model.PageSize
            });
        }

        /// <summary>
        /// Returneaza topul judetelor in functie de numarul de sesizari
        /// </summary>
        /// <param name="model">Detaliile de paginare (default Page=1, PageSize=5)</param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> SesizariJudete(PagingModel model)
        {
            return await _mediator.SendAsync(new StatisticiTopSesizariQuery
            {
                Grupare = TipGrupareStatistici.Judet,
                Formular = null,
                Page = model.Page == 0 ? 1 : model.Page,
                PageSize = model.PageSize == 0 ? 5 : model.PageSize
            });
        }

        /// <summary>
        /// Returneaza topul Sectiilor in functie de numarul de sesizari
        /// </summary>
        /// <param name="model">Detaliile de paginare (default Page=1, PageSize=5)</param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> SesizariSectii(PagingModel model)
        {
            return await _mediator.SendAsync(new StatisticiTopSesizariQuery
            {
                Grupare = TipGrupareStatistici.Sectie,
                Formular = null,
                Page = model.Page == 0 ? 1 : model.Page,
                PageSize = model.PageSize == 0 ? 5 : model.PageSize
            });
        }

        /// <summary>
        /// Returneaza topul judetelor in functie de numarul de sesizari la deschiderea sectiilor
        /// </summary>
        /// <param name="model">Detaliile de paginare (default Page=1, PageSize=5)</param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> SesizariDeschidereJudete(PagingModel model)
        {
            return await _mediator.SendAsync(new StatisticiTopSesizariQuery
            {
                Grupare = TipGrupareStatistici.Judet,
                Formular = null,
                Page = model.Page == 0 ? 1 : model.Page,
                PageSize = model.PageSize == 0 ? 5 : model.PageSize
            });
        }

        /// <summary>
        /// Returneaza topul Sectiilor in functie de numarul de sesizari la deschiderea sectiilor
        /// </summary>
        /// <param name="model">Detaliile de paginare (default Page=1, PageSize=5)</param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> SesizariDeschidereSectii(PagingModel model)
        {
            return await _mediator.SendAsync(new StatisticiTopSesizariQuery
            {
                Grupare = TipGrupareStatistici.Sectie,
                Formular = null,
                Page = model.Page == 0 ? 1 : model.Page,
                PageSize = model.PageSize == 0 ? 5 : model.PageSize
            });
        }

        /// <summary>
        /// Returneaza topul judetelor in functie de numarul de sesizari la numararea voturilor
        /// </summary>
        /// <param name="model">Detaliile de paginare (default Page=1, PageSize=5)</param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> SesizariNumarareJudete(PagingModel model)
        {
            return await _mediator.SendAsync(new StatisticiTopSesizariQuery
            {
                Grupare = TipGrupareStatistici.Judet,
                Formular = "C",
                Page = model.Page == 0 ? 1 : model.Page,
                PageSize = model.PageSize == 0 ? 5 : model.PageSize
            });
        }

        /// <summary>
        /// Returneaza topul Sectiilor in functie de numarul de sesizari la numararea voturilor
        /// </summary>
        /// <param name="model">Detaliile de paginare (default Page=1, PageSize=5)</param>
        /// <returns></returns>
        public async Task<ApiListResponse<SimpleStatisticsModel>> SesizariNumarareSectii(PagingModel model)
        {
            return await _mediator.SendAsync(new StatisticiTopSesizariQuery
            {
                Grupare = TipGrupareStatistici.Sectie,
                Formular = "C",
                Page = model.Page == 0 ? 1 : model.Page,
                PageSize = model.PageSize == 0 ? 5 : model.PageSize
            });
        }
    }
}