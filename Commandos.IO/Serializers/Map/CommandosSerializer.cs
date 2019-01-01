using System.Collections.ObjectModel;
using System.Text;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Characters.Commandos;

namespace Commandos.IO.Serializers.Map
{
    public static class CommandosSerializer
    {
        public const string GreenBeretToken = "COMANDO";
        public const string SniperToken = "FRANCOTIRADOR";
        public const string MarineToken = "LANCHERO";
        public const string SapperToken = "ARTIFICIERO";
        public const string DriverToken = "CONDUCTOR";
        public const string SpyToken = "ESPIA";
        public const string NatashaToken = "NATACHA";
        public const string ThiefToken = "RATERO";
        public const string WilsonToken = "WILSON";
        public const string WhiskyToken = "WHISKY";

        public static bool IsCommado(MultipleRecords multipleRecords)
        {
            var tokenId = multipleRecords.GetStringValue(StringConstants.TokenId);
            switch (tokenId)
            {
                case GreenBeretToken:
                case SniperToken:
                case MarineToken:
                case SapperToken:
                case DriverToken:
                case SpyToken:
                case NatashaToken:
                case ThiefToken:
                case WilsonToken:
                case WhiskyToken:
                    return true;
                default:
                    return false;
            }
        }

        public static Commando Serialize(MultipleRecords multipleRecords)
        {
            var commando = GetCommando(multipleRecords);
            if (commando == null) return null;
            SerializerHelper.PopulateCharacter(commando, multipleRecords);
            return commando;
        }

        private static Commando GetCommando(MultipleRecords multipleRecords)
        {
            var tokenId = multipleRecords.GetStringValue(StringConstants.TokenId);
            switch (tokenId)
            {
                case GreenBeretToken:
                    return new GreenBeret();
                case SniperToken:
                    return new Sniper();
                case MarineToken:
                    return new Marine();
                case SapperToken:
                    return new Sapper();
                case DriverToken:
                    return new Driver();
                case SpyToken:
                    return new Spy();
                case NatashaToken:
                    return new Natasha();
                case ThiefToken:
                    return new Thief();
                //case WilsonToken:
                //  return new Wilson();
                //case WhiskyToken:
                //  return new Whisky();
                default:
                    return null;
            }
        }

        internal static object GetCommandosRecordString(ObservableCollection<Commando> commandos)
        {
            var stringBuilder = new StringBuilder();
            foreach (var commando in commandos)
                stringBuilder.Append($"[ {SerializerHelper.GetCharacterRecordString(commando)} .BANDO ALIADO .HTIP {commando.SecondaryType} " +
                  $".ACCIONES ( ( Ac_DejarPisadasGraficas [ ] ) ( Ac_DejarPisadasLogicas [ ] ) ) {GetBehaviorString(commando)} " +
                  $".USAHAB [ ] .VOLCOLISION ( Cilindro [ .RADIO 12.0 .ALTURA 50.0 ] ) .TIPOCOLISION PEATON .ZONASELECCION ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) {GetMotorString(commando)} " +
                  $".COLORPUNTOLIBRETA ALIADO .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 20.0 .ALTURA 50.0 ] ) {GetAnimationString(commando)} ] ) .CONTENEDOR 1.0 .LISTAS ( CHOC VISI SELE EJEC ) .GEL [ ] " +
                  $".DUMMY [ .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .ANIM {commando.AnimationFileNameComplete} ] ) ] {GetDriveString(commando)} " +
                  $".VISTA ( VistaTriangular [ ] ) .BICHOS ( ) .VELOCIDADES_PREFIJADAS 1.0 .REMOLQUE 1.0 ] ");
            return stringBuilder.ToString().Trim();
        }

        private static string GetBehaviorString(Commando commando)
        {
            if (commando is GreenBeret)
                return ".COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AUPonerCepo [ ] ) ( AULanzarGranada [ .TIPO_GRANADA GAS ] ) ( AUNarcotizar [ ] ) ( AUInteractuar [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUUsarTransfer [ ] ) ( AUBucear [ ] ) ( AUSaltarValla [ ] ) ( AUNadar [ ] ) ( AUUsarVehiculo [ ] ) ( AUMirarPorTransfer [ .CABLE 1.0 .CANALON 1.0 .CALLE 1.0 .FACHADA 0 .ESCALA 1.0 .IMPULSO 1.0 .GANCHO 1.0 ] ) ( AUUsarBotiquin [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AULlevarMuerto [ ] ) ( AUManejarSenuelo [ ] ) ( AUSilbato [ ] ) ( AUAcuchillar [ ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUSaltarPorTransfer [ .CABLE 1.0 .CANALON 1.0 .CALLE 1.0 .FACHADA 0 .ESCALA 1.0 .IMPULSO 1.0 .GANCHO 1.0 ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUEsconderse [ ] ) ( AUEnterrarse [ ] ) ( AUAtontar [ ] ) ( AUGolpearPared [ ] ) ( AUAbrirPuertaInterior [ ] ) ( AUUsarRadio [ ] ) ( AUTreparCable [ ] ) ( AUComidaPerro [ ] ) ( AUUsarComidaPeces [ ] ) ( AULanzarTabaco [ ] ) ( AUPrismaticos [ ] ) ( AUIrPegaoAPared [ ] ) ( AUTransportaObjeto [ ] ) ( AUUsarInterruptor [ .INTERRUPTORES ( RUEDA PALANCA ) ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUAmordazar [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUPonerSenuelo [ ] ) ( AUUsarTenazas [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUDerribarPuerta [ ] ) ( AUUsarBotella [ ] ) ( AUSaltarParacaidas [ .EVENTO_LANZA_PARACAIDAS_LLEGADA_SUELO PLAS ] ) ( AUDeslumbrar [ ] ) ( AUUsarGarfio [ ] ) ( AULlevarWhisky [ ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUActuarSobre [ .TOKENSACTUASOBRE ( ) ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_VALLAS 1.0 .SALTA_ACANTILADOS 1.0 .EVENTO_LANZA_PARACAIDAS_LLEGADA_SUELO PLAS ] )";
            if (commando is Sniper)
                return " .COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AUPonerCepo [ ] ) ( AULanzarGranada [ .TIPO_GRANADA GAS ] ) ( AUNarcotizar [ ] ) ( AUInteractuar [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUSaltarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarTransfer [ ] ) ( AUUsarVehiculo [ ] ) ( AUMirarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarBotiquin [ ] ) ( AUNadar [ ] ) ( AUApuntarPorTransfer [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AUSilbato [ ] ) ( AUPrismaticos [ ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUDispararRifle [ ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUEsconderse [ ] ) ( AUUsarRadio [ ] ) ( AUTreparCable [ .USO_CABLES 0 ] ) ( AUAbrirPuertaInterior [ ] ) ( AUComidaPerro [ ] ) ( AULanzarTabaco [ ] ) ( AULlevarMuerto [ .ARRASTRAR 1.0 ] ) ( AUIrPegaoAPared [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUBucear [ ] ) ( AUAmordazar [ ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUPonerSenuelo [ ] ) ( AUManejarSenuelo [ ] ) ( AUUsarTenazas [ ] ) ( AUGolpearPared [ ] ) ( AUUsarInterruptor [ ] ) ( AUDeslumbrar [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUAtontar [ ] ) ( AUUsarBotella [ ] ) ( AUUsarGarfio [ ] ) ( AULlevarWhisky [ ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUActuarSobre [ ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_ACANTILADOS 1.0 ] )";
            if (commando is Marine)
                return ".COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AULanzarGranada [ .TIPO_GRANADA GAS ] ) ( AUPonerCepo [ ] ) ( AUNarcotizar [ ] ) ( AUInteractuar [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUSaltarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarTransfer [ ] ) ( AUBucear [ ] ) ( AUNadar [ ] ) ( AUUsarVehiculo [ ] ) ( AUMirarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarBotiquin [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AUSilbato [ ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUDesactivarMinaMarina [ ] ) ( AUEsconderse [ ] ) ( AUUsarRadio [ ] ) ( AUTirarseDeCabeza [ ] ) ( AUAbrirPuertaInterior [ ] ) ( AUComidaPerro [ ] ) ( AUUsarComidaPeces [ ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUDispararArpon [ ] ) ( AULanzarTabaco [ ] ) ( AUPrismaticos [ ] ) ( AULlevarMuerto [ .ARRASTRAR 1.0 ] ) ( AUIrPegaoAPared [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUAmordazar [ ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUPonerSenuelo [ ] ) ( AUManejarSenuelo [ ] ) ( AUUsarTenazas [ ] ) ( AUGolpearPared [ ] ) ( AUUsarInterruptor [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUAtontar [ ] ) ( AUUsarBotella [ ] ) ( AULanzarCuchillo [ ] ) ( AUDeslumbrar [ ] ) ( AUUsarGarfio [ ] ) ( AULlevarWhisky [ ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUActuarSobre [ .TOKENSACTUASOBRE ( ) ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_ACANTILADOS 1.0 ] )";
            if (commando is Sapper)
                return ".COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AUNarcotizar [ ] ) ( AUInteractuar [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUSaltarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarTransfer [ ] ) ( AUUsarVehiculo [ .PUEDE_DISPARAR 1.0 ] ) ( AUNadar [ ] ) ( AUUsarTenazas [ ] ) ( AUUsarSoplete [ ] ) ( AUMirarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarBotiquin [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AUDetectarExplosivos [ ] ) ( AUManejarExplosivos [ ] ) ( AUSilbato [ ] ) ( AULanzarGranada [ .TIPO_GRANADA EXPLOSIVA ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AULanzallamas [ ] ) ( AUBazooka [ ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUEsconderse [ ] ) ( AULanzarMolotov [ ] ) ( AUUsarRadio [ ] ) ( AUAbrirPuertaInterior [ ] ) ( AULanzarTabaco [ ] ) ( AUComidaPerro [ ] ) ( AUPrismaticos [ ] ) ( AULlevarMuerto [ .ARRASTRAR 1.0 ] ) ( AUIrPegaoAPared [ ] ) ( AUAsociarBombaATrampa [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUBucear [ ] ) ( AUUsarArmaEstatica [ ] ) ( AUAmordazar [ ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUPonerSenuelo [ ] ) ( AUManejarSenuelo [ ] ) ( AUGolpearPared [ ] ) ( AUUsarInterruptor [ ] ) ( AUUsarBotella [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUAtontar [ ] ) ( AUDeslumbrar [ ] ) ( AULlevarWhisky [ ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUUsarGarfio [ ] ) ( AUActuarSobre [ .TOKENSACTUASOBRE ( ) ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_ACANTILADOS 1.0 ] )";
            if (commando is Driver)
                return ".COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AUNarcotizar [ ] ) ( AUInteractuar [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUSaltarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarTransfer [ ] ) ( AUUsarVehiculo [ ] ) ( AUUsarTenazas [ ] ) ( AUUsarSoplete [ ] ) ( AUReparar [ ] ) ( AUMirarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarBotiquin [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AULlevarMuerto [ .ARRASTRAR 1.0 ] ) ( AUSilbato [ ] ) ( AUPrismaticos [ ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUEsconderse [ ] ) ( AUUsarRadio [ ] ) ( AUAbrirPuertaInterior [ ] ) ( AUComidaPerro [ ] ) ( AULanzarTabaco [ ] ) ( AULlevarMuerto [ .ARRASTRAR 1.0 ] ) ( AUIrPegaoAPared [ ] ) ( AUAtontar [ ] ) ( AUPonerCepo [ ] ) ( AUExcavarTrampaFoso [ ] ) ( AUTenderTrampaCable [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUNadar [ ] ) ( AUBucear [ ] ) ( AUAmordazar [ ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUPonerSenuelo [ ] ) ( AUManejarSenuelo [ ] ) ( AUGolpearPared [ ] ) ( AUUsarInterruptor [ ] ) ( AUUsarBotella [ ] ) ( AUDeslumbrar [ ] ) ( AUUsarGarfio [ ] ) ( AULlevarWhisky [ ] ) ( AULanzarGranada [ .TIPO_GRANADA GAS ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUActuarSobre [ .TOKENSACTUASOBRE ( ) ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_ACANTILADOS 1.0 ] )";
            if (commando is Spy)
                return ".COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AULanzarGranada [ .TIPO_GRANADA GAS ] ) ( AUNarcotizar [ ] ) ( AUInteractuar [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUSaltarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarTransfer [ ] ) ( AUUsarVehiculo [ ] ) ( AUMirarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarBotiquin [ ] ) ( AUDistraerAleman [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AUSilbato [ ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUUsarJeringuilla [ ] ) ( AUEsconderse [ ] ) ( AUUsarRadio [ ] ) ( AUAbrirPuertaInterior [ ] ) ( AUComidaPerro [ ] ) ( AULanzarTabaco [ ] ) ( AUPrismaticos [ ] ) ( AUIrPegaoAPared [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUNadar [ ] ) ( AUBucear [ ] ) ( AUAmordazar [ ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUPonerSenuelo [ ] ) ( AUManejarSenuelo [ ] ) ( AUUsarTenazas [ ] ) ( AUGolpearPared [ ] ) ( AUUsarInterruptor [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUAtontar [ ] ) ( AUUsarBotella [ ] ) ( AUDeslumbrar [ ] ) ( AUUsarGarfio [ ] ) ( AULlevarWhisky [ ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUActuarSobre [ ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_ACANTILADOS 1.0 ] )";
            if (commando is Natasha)
                return ".COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AUNarcotizar [ ] ) ( AUInteractuar [ ] ) ( AUAmordazar [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUSaltarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarTransfer [ ] ) ( AUUsarVehiculo [ ] ) ( AUMirarPorTransfer [ .CABLE 0 .CANALON 0 .CALLE 0 .FACHADA 0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUApuntarPorTransfer [ ] ) ( AUUsarBotiquin [ ] ) ( AUDistraerAleman [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AUSilbato [ ] ) ( AUPrismaticos [ ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUDispararRifle [ ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUEsconderse [ ] ) ( AUUsarRadio [ ] ) ( AUAbrirPuertaInterior [ ] ) ( AUComidaPerro [ ] ) ( AULanzarTabaco [ ] ) ( AUIrPegaoAPared [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUNadar [ ] ) ( AUBucear [ ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUPonerSenuelo [ ] ) ( AUManejarSenuelo [ ] ) ( AUUsarTenazas [ ] ) ( AUGolpearPared [ ] ) ( AUUsarInterruptor [ ] ) ( AUUsarBotella [ ] ) ( AUDeslumbrar [ ] ) ( AUUsarGarfio [ ] ) ( AULlevarWhisky [ ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUAtontar [ .USANDO_BOTELLAS 1.0 ] ) ( AUUsarTelefono [ .PUEDO_MANDAR_A_PUNTO 1.0 ] ) ( AUActuarSobre [ .TOKENSACTUASOBRE ( ) ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_ACANTILADOS 1.0 ] )";
            if (commando is Thief)
                return ".COMPORTAMIENTO ( ComporUsuario [ .ACCIONES ( ( AULanzarGranada [ .TIPO_GRANADA GAS ] ) ( AUInteractuar [ ] ) ( AUPonerCepo [ ] ) ( AUGoTo [ ] ) ( AUCambiarPostura [ ] ) ( AUUsarTransfer [ ] ) ( AUEscalar [ ] ) ( AUNadar [ ] ) ( AUUsarVehiculo [ ] ) ( AUUsarTenazas [ ] ) ( AUSaltarPorTransfer [ .CABLE 1.0 .CANALON 0 .CALLE 1.0 .FACHADA 1.0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUColarsePorTransfer [ ] ) ( AUMirarPorTransfer [ .CABLE 1.0 .CANALON 0 .CALLE 1.0 .FACHADA 1.0 .ESCALA 1.0 .GANCHO 1.0 ] ) ( AUUsarBotiquin [ ] ) ( AUSoltarBicho [ ] ) ( AUCoger [ ] ) ( AUSilbato [ ] ) ( AUDispararArma [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUExaminar [ ] ) ( AUUsarEscala [ ] ) ( AUUsarAscensor [ ] ) ( AUDetenido [ ] ) ( AUForzarCerradura [ ] ) ( AUEsconderse [ ] ) ( AUGolpearPared [ ] ) ( AUUsarRadio [ ] ) ( AUTreparCable [ ] ) ( AUTreparPared [ .CRAMPEA 1.0 ] ) ( AUAbrirPuertaInterior [ ] ) ( AUPegarseABicho [ ] ) ( AUComidaPerro [ ] ) ( AULanzarTabaco [ ] ) ( AULlevarMuerto [ .ARRASTRAR 1.0 ] ) ( AUPrismaticos [ ] ) ( AUIrPegaoAPared [ ] ) ( AUAbrirCajaFuerte [ ] ) ( AUPonerseTraje [ ] ) ( AULiberarChusma [ ] ) ( AUBucear [ ] ) ( AUDispararTirachinas [ ] ) ( AUUsarMuneco [ ] ) ( AUUsarInterruptor [ ] ) ( AUSoltarEscalaEnrollable [ ] ) ( AUPonerSenuelo [ ] ) ( AUManejarSenuelo [ ] ) ( AUDispararMetralleta [ ] ) ( AUDispararRifleCorto [ ] ) ( AUApostarse [ .VIGILADOR [ .LONG_NORMAL 600.0 .AMPL_NORMAL 120 ] ] ) ( AUAtontar [ .EMPUJA 1.0 ] ) ( AUNarcotizar [ ] ) ( AUUsarBotella [ ] ) ( AUUsarTelefono [ ] ) ( AUDeslumbrar [ ] ) ( AUUsarGarfio [ ] ) ( AULlevarWhisky [ ] ) ( AUAbrirPuertaConLlave [ ] ) ( AUActuarSobre [ .TOKENSACTUASOBRE ( ) ] ) ) .ACCIONES2 ( ( AUUsarJeringuilla [ ] ) ( AUAbrirCajaFuerte [ ] ) ) .GESTOR_MOVIMIENTO [ .PATRULLAJE [ ] ] .EMPIEZA_TORTURADO 0 .SALTA_ACANTILADOS 1.0 ] )";
            return null;
        }

        private static string GetAnimationString(Commando commando)
        {
            if (commando is GreenBeret)
                return $".ANIM {commando.AnimationFileNameComplete} .MOTIONBLUR_CORRIENDO 1.0";
            return $".ANIM {commando.AnimationFileNameComplete}";
        }

        private static string GetMotorString(Commando commando)
        {
            if (commando is Thief)
                return ".MOTOR ( MotorPeaton [ .ATRAVIESAALAMBRADAS 1.0 ] )";
            return ".MOTOR ( MotorPeaton [ .ATRAVIESAALAMBRADAS 0 ] )";
        }

        private static string GetDriveString(Commando commando)
        {
            if (commando is GreenBeret)
                return ".PUEDE_CONDUCIR ( GLOBO WILLIS CAMION LANCHA_MOTORA ASCENSOR MONTA SILLA_ALIADA )";
            if (commando is Sniper)
                return ".PUEDE_CONDUCIR ( GLOBO WILLIS CAMION LANCHA_MOTORA ASCENSOR MONTA SILLA_ALIADA )";
            if (commando is Marine)
                return ".PUEDE_CONDUCIR ( GLOBO WILLIS ZODIAK CAMION LANCHA_MOTORA ASCENSOR MONTA SILLA_ALIADA )";
            if (commando is Sapper)
                return ".PUEDE_CONDUCIR ( GLOBO WILLIS CAMION CANON LANCHA_MOTORA NIDO_AMETRALLADORAS ASCENSOR MONTA SILLA_ALIADA )";
            if (commando is Driver)
                return ".PUEDE_CONDUCIR ( GLOBO TANQUE WILLIS CAMION LANCHA_MOTORA ASCENSOR MONTA SILLA_ALIADA )";
            if (commando is Spy)
                return ".PUEDE_CONDUCIR ( GLOBO WILLIS CAMION LANCHA_MOTORA ASCENSOR MONTA SILLA_ALIADA )";
            if (commando is Natasha)
                return ".PUEDE_CONDUCIR ( GLOBO WILLIS CAMION LANCHA_MOTORA ASCENSOR MONTA SILLA_ALIADA )";
            if (commando is Thief)
                return ".PUEDE_CONDUCIR ( GLOBO WILLIS CAMION LANCHA_MOTORA ASCENSOR MONTA ELEFANTE SILLA_ALIADA )";
            return null;
        }
    }
}
