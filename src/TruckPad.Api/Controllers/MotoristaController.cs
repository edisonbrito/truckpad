using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruckPad.Api.Helper;
using TruckPad.Api.Interfaces;
using TruckPad.Api.Model.Enum;
using TruckPad.Api.ViewModel;
using TruckPad.Domain.Enum;
using TruckPad.Domain.Model;

namespace TruckPad.Api.Controllers
{
    [Route("/api/motorista")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IUnitOfWork _uow;
        public MotoristaController(IMotoristaRepository motoristaRepository, IUnitOfWork uow)
        {
            _motoristaRepository = motoristaRepository;
            _uow = uow;
        }

        //Mostrar uma lista de origem e destino agrupado por cada um dos tipos
        //A Fazer dúvida


        //FAZENDO
        [HttpGet("passagem-caminhao-periodo")]
        public async Task<ActionResult<IEnumerable<Motorista>>> Get(Periodo periodo)
        {
            var motorista = await _motoristaRepository.GetPeriod(periodo);
            return Ok(motorista);
        }

        //OK
        [HttpGet("volta-origem-sem-carga")]
        public async Task<ActionResult<IEnumerable<Motorista>>> ObterMotoristasSemCarga()
        {
            var carga = await _motoristaRepository.GetVehicleOriginunLoaded();
            return Ok(carga);
        }        

        //OK
        [HttpGet("veiculo-proprio")]
        public async Task<ActionResult<IEnumerable<Motorista>>> ObterMotoristasDonoDeCaminhao()
        {
            var motoristas = await _motoristaRepository.GetVehicleOwners();
            return Ok(motoristas);
        }


        //OK
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorista>> Get(Guid id)
        {
            var motorista = await _motoristaRepository.GetById(id);
            return Ok(motorista);
        }


        //OK
        [HttpPost]
        [ProducesResponseType(typeof(Motorista), 201)]
        [ProducesResponseType(typeof(Motorista), 400)]
        public async Task<ActionResult<Motorista>> Post([FromBody] MotoristaViewModel motorista)
        {
            var motoristaPersistir = new Motorista
                (motorista.Nome,
                motorista.Idade,
                motorista.Sexo,
                motorista.PossuiVeiculo,
                motorista.CNH,               
                new Veiculo(motorista.veiculo.Carregado, 
                            motorista.veiculo.TipoVeiculo, 
                            motorista.veiculo.Placa, 
                            motorista.veiculo.DataPassagemTerminal)
               ,motorista.CargaParaVoltaDestino);

            _motoristaRepository.Add(motoristaPersistir);

            var testMotorista = await _motoristaRepository.GetById(motoristaPersistir.Id);

            await _uow.Commit();

            testMotorista = await _motoristaRepository.GetById(motoristaPersistir.Id);

            return Ok(testMotorista);
        }


        //OK
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Motorista), 200)]
        [ProducesResponseType(typeof(Motorista), 400)]
        public async Task<ActionResult<Motorista>> Put(Guid id, [FromBody] MotoristaViewModel motorista)
        {
            var motoristaUpdade = new Motorista
                (id,
                motorista.Nome,
                motorista.Idade,
                motorista.Sexo,
                motorista.PossuiVeiculo,
                motorista.CNH,
                new Veiculo(motorista.veiculo.Carregado, 
                            motorista.veiculo.TipoVeiculo, 
                            motorista.veiculo.Placa)
                ,motorista.CargaParaVoltaDestino);

            _motoristaRepository.Update(motoristaUpdade);

            await _uow.Commit();

            return Ok(await _motoristaRepository.GetById(id));
        }


        //OK
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Motorista), 200)]
        [ProducesResponseType(typeof(Motorista), 400)]
        public async Task<ActionResult>  Delete(Guid id)
        {
            _motoristaRepository.Remove(id);

            var testProduct = await _motoristaRepository.GetById(id);

            await _uow.Commit();

            testProduct = await _motoristaRepository.GetById(id);

            return Ok();
        }
    }
}