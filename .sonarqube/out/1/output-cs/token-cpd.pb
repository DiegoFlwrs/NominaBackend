á"
sC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\Services\ReporteNominaService.cs
	namespace 	
Nomina
 
. 
Application 
. 
Services %
{ 
public 

class  
ReporteNominaService %
:& '!
IReporteNominaService( =
{ 
private 
readonly $
IReporteNominaRepository 1
_reporteRepository2 D
;D E
public  
ReporteNominaService #
(# $$
IReporteNominaRepository$ <
reporteRepository= N
)N O
{ 	
_reporteRepository 
=  
reporteRepository! 2
;2 3
} 	
public 
async 
Task 
< 
List 
< 
ReporteNominaView 0
>0 1
>1 2
GenerarReporteAsync3 F
(F G
string 
? 
PeriodoCodigo !
,! "
string 
? 
departamentoCodigo &
,& '
string 
? 
cargoCodigo 
,  
string 
? 
tipoContratoCodigo &
)& '
{ 	
var 
reporte 
= 
await 
_reporteRepository  2
.2 3%
ObtenerReporteNominaAsync3 L
(L M
PeriodoCodigo 
, 
departamentoCodigo   "
,  " #
cargoCodigo!! 
,!! 
tipoContratoCodigo"" "
)## 
;## 
return%% 
reporte%% 
??%% 
new%% !
List%%" &
<%%& '
ReporteNominaView%%' 8
>%%8 9
(%%9 :
)%%: ;
;%%; <
}&& 	
public(( 
async(( 
Task(( 
<(( 
byte(( 
[(( 
]((  
>((  !"
GenerarReportePdfAsync((" 8
(((8 9
string)) 
?)) 
PeriodoCodigo)) !
,))! "
string** 
?** 
departamentoCodigo** &
,**& '
string++ 
?++ 
cargoCodigo++ 
,++  
string,, 
?,, 
tipoContratoCodigo,, &
),,& '
{-- 	
var// 
reporteData// 
=// 
await// #
_reporteRepository//$ 6
.//6 7%
ObtenerReporteNominaAsync//7 P
(//P Q
PeriodoCodigo00 
,00 
departamentoCodigo00 1
,001 2
cargoCodigo003 >
,00> ?
tipoContratoCodigo00@ R
)11 
;11 
if44 
(44 
reporteData44 
==44 
null44 #
||44$ &
reporteData44' 2
.442 3
Count443 8
==449 ;
$num44< =
)44= >
{55 
throw66 
new66 
BusinessException66 +
(66+ ,
$str66, |
)66| }
;66} ~
}77 
var99 
fechas99 
=99 
reporteData99 $
.99$ %
First99% *
(99* +
)99+ ,
;99, -
var;; 
fechaInicio;; 
=;; 
DateTime;; &
.;;& '

ParseExact;;' 1
(;;1 2
fechas;;2 8
.;;8 9
PeriodoInicio;;9 F
,;;F G
$str;;G S
,;;S T
CultureInfo;;T _
.;;_ `
InvariantCulture;;` p
);;p q
;;;q r
var<< 
fechaFin<< 
=<< 
DateTime<< #
.<<# $

ParseExact<<$ .
(<<. /
fechas<</ 5
.<<5 6

PeriodoFin<<6 @
,<<@ A
$str<<B N
,<<N O
CultureInfo<<P [
.<<[ \
InvariantCulture<<\ l
)<<l m
;<<m n
return?? 
PdfGeneratorHelper?? %
.??% &
GenerarNominaPdf??& 6
(??6 7
reporteData??7 B
.??B C
ToList??C I
(??I J
)??J K
,??K L
fechaInicio??M X
,??X Y
fechaFin??Z b
)??b c
;??c d
}@@ 	
}AA 
}BB øª
lC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\Services\NominaService.cs
	namespace 	
Nomina
 
. 
Application 
. 
Services %
{ 
public 

class 
NominaService 
:  
INominaService! /
{ 
private 
readonly 
INominaRepository *
_repository+ 6
;6 7
public 
NominaService 
( 
INominaRepository .

repository/ 9
)9 :
{ 	
_repository 
= 

repository $
;$ %
} 	
public 
async 
Task 
< 
IEnumerable %
<% &

NominaView& 0
>0 1
>1 2
ProcesarNominaAsync3 F
(F G
NominaFiltroRequestG Z
request[ b
)b c
{ 	
return 
await 
_repository $
.$ %!
ConsultarNominasAsync% :
(: ;
request; B
.B C
CodigoPeriodoC P
)P Q
;Q R
} 	
public   
async   
Task   
<   
IEnumerable   %
<  % &
int  & )
>  ) *
>  * +
ObtenerAniosAsync  , =
(  = >
)  > ?
{!! 	
var"" 
periodos"" 
="" 
await""  
_repository""! ,
."", - 
ObtenerPeriodosAsync""- A
(""A B
)""B C
;""C D
var## 
aniosDistintos## 
=##  
periodos##! )
.$$ 
Select$$ 
($$ 
p$$ 
=>$$ 
p$$ 
.$$ 
PeriodoAnio$$ *
)$$* +
.%% 
Distinct%% 
(%% 
)%% 
.&& 
OrderByDescending&& "
(&&" #
a&&# $
=>&&% '
a&&( )
)&&) *
.'' 
ToList'' 
('' 
)'' 
;'' 
return)) 
aniosDistintos)) !
;))! "
}** 	
public,, 
async,, 
Task,, 
<,, 
IEnumerable,, %
<,,% &
int,,& )
>,,) *
>,,* +
ObtenerMesesAsync,,, =
(,,= >
),,> ?
{-- 	
var.. 
periodos.. 
=.. 
await..  
_repository..! ,
..., - 
ObtenerPeriodosAsync..- A
(..A B
)..B C
;..C D
var// 
mesesDistintos// 
=//  
periodos//! )
.00 
Select00 
(00 
p00 
=>00 
p00 
.00 

PeriodoMes00 )
)00) *
.11 
Distinct11 
(11 
)11 
.22 
OrderByDescending22 "
(22" #
m22# $
=>22% '
m22( )
)22) *
.33 
ToList33 
(33 
)33 
;33 
return55 
mesesDistintos55 !
;55! "
}66 	
public88 
async88 
Task88 
<88 
IEnumerable88 %
<88% &
DepartamentoDto88& 5
>885 6
>886 7%
ObtenerDepartamentosAsync888 Q
(88Q R
)88R S
{99 	
var:: 
departamentos:: 
=:: 
await::  %
_repository::& 1
.::1 2%
ObtenerDepartamentosAsync::2 K
(::K L
)::L M
;::M N
var<< 
	resultado<< 
=<< 
departamentos<< )
.<<) *
Select<<* 0
(<<0 1
t<<1 2
=><<3 5
new<<6 9
DepartamentoDto<<: I
{== 
DepartamentoCodigo>> "
=>># $
t>>% &
.>>& '
DepartamentoCodigo>>' 9
,>>9 :
DepartamentoNombre?? "
=??# $
t??% &
.??& '
DepartamentoNombre??' 9
}@@ 
)@@ 
;@@ 
returnBB 
	resultadoBB 
;BB 
}CC 	
publicEE 
asyncEE 
TaskEE 
<EE 
IEnumerableEE %
<EE% &

PeriodoDtoEE& 0
>EE0 1
>EE1 2
ObtenerPeriodoAsyncEE3 F
(EEF G
)EEG H
{FF 	
varGG 
periodosGG 
=GG 
awaitGG  
_repositoryGG! ,
.GG, - 
ObtenerPeriodosAsyncGG- A
(GGA B
)GGB C
;GGC D
varII 
	resultadoII 
=II 
periodosII $
.II$ %
SelectII% +
(II+ ,
tII, -
=>II. 0
newII1 4

PeriodoDtoII5 ?
{JJ 
PeriodoCodigoKK 
=KK 
tKK  !
.KK! "
PeriodoCodigoKK" /
!KK/ 0
.KK0 1
TrimKK1 5
(KK5 6
)KK6 7
,KK7 8
PeriodoDescripcionLL "
=LL# $
tLL% &
.LL& '
PeriodoAnioLL' 2
+LL3 4
$strLL5 :
+LL; <
HelperLL= C
.LLC D
ObtenerNombreMesLLD T
(LLT U
tLLU V
.LLV W

PeriodoMesLLW a
)LLa b
+LLc d
$strLLe i
+LLj k
HelperLLl r
.LLr s 
ObtenerNombreEstado	LLs Ü
(
LLÜ á
t
LLá à
.
LLà â
PeriodoEstado
LLâ ñ
!
LLñ ó
)
LLó ò
+
LLô ö
$str
LLõ ü
,
LLü †
PeriodoEstadoMM 
=MM 
tMM  !
.MM! "
PeriodoEstadoMM" /
!MM/ 0
}NN 
)NN 
;NN 
returnPP 
	resultadoPP 
;PP 
}QQ 	
publicSS 
asyncSS 
TaskSS 
<SS 
IEnumerableSS %
<SS% &
ContratoDtoSS& 1
>SS1 2
>SS2 3 
ObtenerContratoAsyncSS4 H
(SSH I
)SSI J
{TT 	
varUU 
	contratosUU 
=UU 
awaitUU !
_repositoryUU" -
.UU- . 
ObtenerContratoAsyncUU. B
(UUB C
)UUC D
;UUD E
varWW 
	resultadoWW 
=WW 
	contratosWW %
.WW% &
SelectWW& ,
(WW, -
tWW- .
=>WW/ 1
newWW2 5
ContratoDtoWW6 A
{XX 
ContratoCodigoYY 
=YY  
tYY! "
.YY" #
ContratoCodigoYY# 1
.YY1 2
TrimYY2 6
(YY6 7
)YY7 8
,YY8 9
EmpleadoDescripcionZZ #
=ZZ$ %
tZZ& '
.ZZ' (
ContratoCodigoZZ( 6
.ZZ6 7
TrimZZ7 ;
(ZZ; <
)ZZ< =
+ZZ> ?
$strZZ@ E
+ZZF G
tZZH I
.ZZI J
EmpleadoZZJ R
!ZZR S
.ZZS T
EmpleadoNombreZZT b
+ZZc d
$strZZe h
+ZZi j
tZZk l
.ZZl m
EmpleadoZZm u
.ZZu v
EmpleadoApellido	ZZv Ü
}[[ 
)[[ 
;[[ 
return]] 
	resultado]] 
;]] 
}^^ 	
publicaa 
asyncaa 
Taskaa 
CrearNominaAsyncaa *
(aa* +
NominaRequestaa+ 8
requestaa9 @
)aa@ A
{bb 	
vardd 
periodosdd 
=dd 
awaitdd  
_repositorydd! ,
.dd, - 
ObtenerPeriodosAsyncdd- A
(ddA B
)ddB C
;ddC D
varee 
periodoee 
=ee 
periodosee "
.ee" #
FirstOrDefaultee# 1
(ee1 2
pee2 3
=>ee4 6
pee7 8
.ee8 9
PeriodoCodigoee9 F
!eeF G
.eeG H
TrimeeH L
(eeL M
)eeM N
==eeO Q
requesteeR Y
.eeY Z
PeriodoCodigoeeZ g
)eeg h
;eeh i
varff 
hoyff 
=ff 
DateTimeff 
.ff 
Nowff "
.ff" #
Dateff# '
;ff' (
ifhh 
(hh 
periodohh 
==hh 
nullhh 
)hh  
throwii 
newii 
BusinessExceptionii +
(ii+ ,
$strii, P
)iiP Q
;iiQ R
ifkk 
(kk 
periodokk 
.kk 
PeriodoEstadokk %
==kk& (
$strkk) ,
)kk, -
throwll 
newll 
BusinessExceptionll +
(ll+ ,
$strll, K
)llK L
;llL M
ifnn 
(nn 
periodonn 
.nn 
PeriodoEstadonn %
==nn& (
$strnn) ,
)nn, -
{oo 
throwpp 
newpp 
BusinessExceptionpp +
(pp+ ,
$strpp, R
)ppR S
;ppS T
}qq 
varuu 
parametrosSistemauu !
=uu" #
awaituu$ )
_repositoryuu* 5
.uu5 6)
ObtenerParametrosSistemaAsyncuu6 S
(uuS T
)uuT U
;uuU V
ifvv 
(vv 
parametrosSistemavv !
==vv" $
nullvv% )
)vv) *
throwww 
newww 
BusinessExceptionww +
(ww+ ,
$strww, [
)ww[ \
;ww\ ]
decimalyy 
RMVyy 
=yy 
parametrosSistemayy +
.yy+ ,
FirstOrDefaultyy, :
(yy: ;
pyy; <
=>yy= ?
pyy@ A
.yyA B
ParametroCodigoyyB Q
==yyR T
$stryyU \
)yy\ ]
?yy] ^
.yy^ _
ParametroValoryy_ m
??yyn p
$numyyq s
;yys t
decimalzz 
UITzz 
=zz 
parametrosSistemazz +
.zz+ ,
FirstOrDefaultzz, :
(zz: ;
pzz; <
=>zz= ?
pzz@ A
.zzA B
ParametroCodigozzB Q
==zzR T
$strzzU \
)zz\ ]
?zz] ^
.zz^ _
ParametroValorzz_ m
??zzn p
$numzzq s
;zzs t
if|| 
(|| 
RMV|| 
<=|| 
$num|| 
|||| 
UIT|| 
<=||  "
$num||# $
)||$ %
{}} 
throw~~ 
new~~ 
BusinessException~~ +
(~~+ ,
$str~~, o
)~~o p
;~~p q
} 
var
ÅÅ 
	contratos
ÅÅ 
=
ÅÅ 
await
ÅÅ !
_repository
ÅÅ" -
.
ÅÅ- ."
ObtenerContratoAsync
ÅÅ. B
(
ÅÅB C
)
ÅÅC D
;
ÅÅD E
var
ÖÖ 
contratosVigentes
ÖÖ !
=
ÖÖ" #
	contratos
ÖÖ$ -
.
ÖÖ- .
Where
ÖÖ. 3
(
ÖÖ3 4
c
ÖÖ4 5
=>
ÖÖ6 8
c
ÜÜ 
.
ÜÜ 
ContratoEstado
ÜÜ  
.
ÜÜ  !
Trim
ÜÜ! %
(
ÜÜ% &
)
ÜÜ& '
==
ÜÜ( *
$str
ÜÜ+ .
&&
ÜÜ/ 1
c
áá 
.
áá !
ContratoFechaInicio
áá %
.
áá% &
HasValue
áá& .
&&
áá/ 1
c
àà 
.
àà 
ContratoFechaFin
àà "
.
àà" #
HasValue
àà# +
&&
àà, .
c
ââ 
.
ââ !
ContratoFechaInicio
ââ %
.
ââ% &
Value
ââ& +
<=
ââ, .
hoy
ââ/ 2
&&
ââ3 5
c
ää 
.
ää 
ContratoFechaFin
ää "
.
ää" #
Value
ää# (
>=
ää) +
hoy
ää, /
)
ãã 
.
ãã 
ToList
ãã 
(
ãã 
)
ãã 
;
ãã 
if
çç 
(
çç 
contratosVigentes
çç !
.
çç! "
Count
çç" '
==
çç( *
$num
çç+ ,
)
çç, -
{
éé 
throw
èè 
new
èè 
BusinessException
èè +
(
èè+ ,
$str
èè, j
)
èèj k
;
èèk l
}
êê 
var
íí 
nominasGeneradas
íí  
=
íí! "
new
íí# &
List
íí' +
<
íí+ ,
NuevaNominaDto
íí, :
>
íí: ;
(
íí; <
)
íí< =
;
íí= >
foreach
îî 
(
îî 
var
îî 
contrato
îî !
in
îî" $
contratosVigentes
îî% 6
)
îî6 7
{
ïï 
var
ññ 
empleado
ññ 
=
ññ 
contrato
ññ '
.
ññ' (
Empleado
ññ( 0
;
ññ0 1
decimal
õõ  
asignacionFamiliar
õõ *
=
õõ+ ,
ReglasNomina
õõ- 9
.
õõ9 :(
CalcularAsignacionFamiliar
õõ: T
(
õõT U
empleado
õõU ]
!
õõ] ^
.
õõ^ _ 
EmpleadoTieneHijos
õõ_ q
??
õõr t
false
õõu z
,
õõz {
RMV
õõ| 
)õõ Ä
;õõÄ Å
var
ùù 
	conceptos
ùù 
=
ùù 
await
ùù  %
_repository
ùù& 1
.
ùù1 26
(ObtenerConceptosPorContratoYPeriodoAsync
ùù2 Z
(
ùùZ [
contrato
ûû 
.
ûû 
ContratoCodigo
ûû +
,
ûû+ ,
request
ûû- 4
.
ûû4 5
PeriodoCodigo
ûû5 B
)
ûûB C
;
ûûC D
int
†† 
horasExtras
†† 
=
††  !
	conceptos
††" +
.
°° 
Where
°° 
(
°° 
c
°° 
=>
°° 
c
°°  !
.
°°! "
TipoConcepto
°°" .
==
°°/ 1
$str
°°2 ?
)
°°? @
.
¢¢ 
Sum
¢¢ 
(
¢¢ 
c
¢¢ 
=>
¢¢ 
c
¢¢ 
.
¢¢  
HorasExtras
¢¢  +
??
¢¢, .
$num
¢¢/ 0
)
¢¢0 1
;
¢¢1 2
decimal
•• 
pagoHorasExtras
•• '
=
••( )
ReglasNomina
••* 6
.
••6 7%
CalcularPagoHorasExtras
••7 N
(
••N O
contrato
¶¶ 
.
¶¶ 
ContratoSalario
¶¶ ,
,
¶¶, -
horasExtras
¶¶. 9
)
¶¶9 :
;
¶¶: ;
decimal
©© 
bonificaciones
©© &
=
©©' (
	conceptos
©©) 2
.
™™ 
Where
™™ 
(
™™ 
c
™™ 
=>
™™ 
c
™™  !
.
™™! "
TipoConcepto
™™" .
==
™™/ 1
$str
™™2 @
)
™™@ A
.
´´ 
Sum
´´ 
(
´´ 
c
´´ 
=>
´´ 
c
´´ 
.
´´  
Monto
´´  %
??
´´& (
$num
´´) *
)
´´* +
;
´´+ ,
decimal
ÆÆ 
totalIngresos
ÆÆ %
=
ÆÆ& '
ReglasNomina
ÆÆ( 4
.
ÆÆ4 5!
CalcularSueldoBruto
ÆÆ5 H
(
ÆÆH I
contrato
ÆÆI Q
.
ÆÆQ R
ContratoSalario
ÆÆR a
,
ÆÆa b 
asignacionFamiliar
ÆÆc u
,
ÆÆu v
pagoHorasExtrasÆÆw Ü
,ÆÆÜ á
bonificacionesÆÆà ñ
)ÆÆñ ó
;ÆÆó ò
decimal
±± 
descuentoEssalud
±± (
=
±±) *
ReglasNomina
±±+ 7
.
±±7 8
CalcularEssalud
±±8 G
(
±±G H
totalIngresos
±±H U
)
±±U V
;
±±V W
decimal
µµ 
porcetajePension
µµ (
=
µµ) *
parametrosSistema
µµ+ <
.
µµ< =
FirstOrDefault
µµ= K
(
µµK L
p
µµL M
=>
µµN P
p
µµQ R
.
µµR S
ParametroCodigo
µµS b
==
µµc e
empleado
µµf n
.
µµn o
EmpleadoAFP
µµo z
)
µµz {
?
µµ{ |
.
µµ| }
ParametroValorµµ} ã
??µµå é
$numµµè ë
;µµë í
decimal
∑∑ 
descuentoPension
∑∑ (
=
∑∑) *
ReglasNomina
∑∑+ 7
.
∑∑7 8&
CalcularDescuentoPension
∑∑8 P
(
∑∑P Q
empleado
∑∑Q Y
.
∑∑Y Z!
EmpleadoTipoPension
∑∑Z m
??
∑∑n p
$str
∑∑q s
,
∑∑s t
totalIngresos∑∑u Ç
,∑∑Ç É
(∑∑Ñ Ö 
porcetajePension∑∑Ö ï
/∑∑ï ñ
$num∑∑ñ ô
)∑∑ô ö
)∑∑ö õ
;∑∑õ ú
decimal
∫∫ 
rentaQuinta
∫∫ #
=
∫∫$ %
ReglasNomina
∫∫& 2
.
∫∫2 3!
CalcularRentaQuinta
∫∫3 F
(
∫∫F G
totalIngresos
∫∫G T
*
∫∫U V
$num
∫∫W Y
,
∫∫Y Z
UIT
∫∫[ ^
)
∫∫^ _
;
∫∫_ `
decimal
ΩΩ #
descuentosAdicionales
ΩΩ -
=
ΩΩ. /
	conceptos
ΩΩ0 9
.
ææ 
Where
ææ 
(
ææ 
c
ææ 
=>
ææ 
c
ææ  !
.
ææ! "
TipoConcepto
ææ" .
==
ææ/ 1
$str
ææ2 =
)
ææ= >
.
øø 
Sum
øø 
(
øø 
c
øø 
=>
øø 
c
øø 
.
øø  
Monto
øø  %
??
øø& (
$num
øø) *
)
øø* +
;
øø+ ,
decimal
¬¬ 
totalDescuentos
¬¬ '
=
¬¬( )
ReglasNomina
¬¬* 6
.
¬¬6 70
"CalcularTotalDescuentosAdicionales
¬¬7 Y
(
¬¬Y Z
descuentoEssalud
¬¬Z j
,
¬¬j k
descuentoPension
¬¬l |
,
¬¬| }
rentaQuinta¬¬~ â
,¬¬â ä%
descuentosAdicionales¬¬ã †
)¬¬† °
;¬¬° ¢
decimal
≈≈ 

sueldoNeto
≈≈ "
=
≈≈# $
ReglasNomina
≈≈% 1
.
≈≈1 2 
CalcularSueldoNeto
≈≈2 D
(
≈≈D E
totalIngresos
≈≈E R
,
≈≈R S
totalDescuentos
≈≈T c
)
≈≈c d
;
≈≈d e
if
»» 
(
»» 
!
»» 
ReglasNomina
»» !
.
»»! "!
ValidarSueldoMinimo
»»" 5
(
»»5 6

sueldoNeto
»»6 @
,
»»@ A
RMV
»»B E
)
»»E F
)
»»F G
{
…… 
throw
   
new
   
BusinessException
   /
(
  / 0
$"
ÀÀ 
$str
ÀÀ ,
{
ÀÀ, -
empleado
ÀÀ- 5
.
ÀÀ5 6
EmpleadoNombre
ÀÀ6 D
}
ÀÀD E
$str
ÀÀE v
"
ÀÀv w
)
ÀÀw x
;
ÀÀx y
}
ÃÃ 
nominasGeneradas
ŒŒ  
.
ŒŒ  !
Add
ŒŒ! $
(
ŒŒ$ %
new
ŒŒ% (
NuevaNominaDto
ŒŒ) 7
{
œœ 
ContratoCodigo
–– "
=
––# $
contrato
––% -
.
––- .
ContratoCodigo
––. <
,
––< =
PeriodoCodigo
—— !
=
——" #
request
——$ +
.
——+ ,
PeriodoCodigo
——, 9
,
——9 :
nominaHorasExtras
““ %
=
““& '
horasExtras
““( 3
,
““3 4$
nominaMontoHorasExtras
”” *
=
””+ ,
pagoHorasExtras
””- <
,
””< =
Bonificaciones
‘‘ "
=
‘‘# $
bonificaciones
‘‘% 3
,
‘‘3 4&
nominaAsignacionFamiliar
’’ ,
=
’’- . 
asignacionFamiliar
’’/ A
,
’’A B$
nominaDescuentoPension
÷÷ *
=
÷÷+ ,
descuentoPension
÷÷- =
,
÷÷= >"
nominaDescuentoIR5ta
◊◊ (
=
◊◊( )
rentaQuinta
◊◊* 5
,
◊◊5 6!
nominaAporteEssalud
ÿÿ '
=
ÿÿ' (
descuentoEssalud
ÿÿ) 9
,
ÿÿ9 :#
nominaOtrosDescuentos
ŸŸ )
=
ŸŸ) *#
descuentosAdicionales
ŸŸ+ @
,
ŸŸ@ A
TotalIngresos
⁄⁄ !
=
⁄⁄" #
totalIngresos
⁄⁄$ 1
,
⁄⁄1 2
TotalDescuentos
€€ #
=
€€$ %
totalDescuentos
€€& 5
,
€€5 6

SueldoNeto
‹‹ 
=
‹‹  

sueldoNeto
‹‹! +
}
›› 
)
›› 
;
›› 
}
ﬁﬁ 
var
‡‡ 
ultimoCodigo
‡‡ 
=
‡‡ 
await
‡‡ $
_repository
‡‡% 0
.
‡‡0 1,
ObtenerUltimoCodigoNominaAsync
‡‡1 O
(
‡‡O P
)
‡‡P Q
;
‡‡Q R
int
·· 
numero
·· 
=
·· 
string
·· 
.
··  
IsNullOrEmpty
··  -
(
··- .
ultimoCodigo
··. :
)
··: ;
?
··< =
$num
··> ?
:
··@ A
int
··B E
.
··E F
Parse
··F K
(
··K L
ultimoCodigo
··L X
.
··X Y
	Substring
··Y b
(
··b c
$num
··c d
)
··d e
)
··e f
;
··f g
foreach
„„ 
(
„„ 
var
„„ 
nomina
„„ 
in
„„  "
nominasGeneradas
„„# 3
)
„„3 4
{
‰‰ 
numero
ÂÂ 
++
ÂÂ 
;
ÂÂ 
string
ÊÊ 
nuevoCodigo
ÊÊ "
=
ÊÊ# $
$"
ÊÊ% '
$str
ÊÊ' *
{
ÊÊ* +
numero
ÊÊ+ 1
.
ÊÊ1 2
ToString
ÊÊ2 :
(
ÊÊ: ;
$str
ÊÊ; ?
)
ÊÊ? @
}
ÊÊ@ A
"
ÊÊA B
;
ÊÊB C
await
ËË 
_repository
ËË !
.
ËË! "!
InsertarNominaAsync
ËË" 5
(
ËË5 6
nominaCodigo
ÈÈ  
:
ÈÈ  !
nuevoCodigo
ÈÈ" -
,
ÈÈ- .
periodoCodigo
ÍÍ !
:
ÍÍ! "
nomina
ÍÍ# )
.
ÍÍ) *
PeriodoCodigo
ÍÍ* 7
,
ÍÍ7 8
contratoCodigo
ÎÎ "
:
ÎÎ" #
nomina
ÎÎ$ *
.
ÎÎ* +
ContratoCodigo
ÎÎ+ 9
,
ÎÎ9 :
nominaHorasExtras
ÏÏ %
:
ÏÏ% &
nomina
ÏÏ' -
.
ÏÏ- .
nominaHorasExtras
ÏÏ. ?
,
ÏÏ? @$
nominaMontoHorasExtras
ÌÌ *
:
ÌÌ* +
nomina
ÌÌ, 2
.
ÌÌ2 3$
nominaMontoHorasExtras
ÌÌ3 I
,
ÌÌI J 
nominaBonificacion
ÓÓ &
:
ÓÓ& '
nomina
ÓÓ( .
.
ÓÓ. /
Bonificaciones
ÓÓ/ =
,
ÓÓ= >&
nominaAsignacionFamiliar
ÔÔ ,
:
ÔÔ, -
nomina
ÔÔ. 4
.
ÔÔ4 5&
nominaAsignacionFamiliar
ÔÔ5 M
,
ÔÔM N$
nominaDescuentoPension
 *
:
* +
nomina
, 2
.
2 3$
nominaDescuentoPension
3 I
,
I J"
nominaDescuentoIR5ta
ÒÒ (
:
ÒÒ( )
nomina
ÒÒ* 0
.
ÒÒ0 1"
nominaDescuentoIR5ta
ÒÒ1 E
,
ÒÒE F!
nominaAporteEssalud
ÚÚ '
:
ÚÚ' (
nomina
ÚÚ) /
.
ÚÚ/ 0!
nominaAporteEssalud
ÚÚ0 C
,
ÚÚC D#
nominaOtrosDescuentos
ÛÛ )
:
ÛÛ) *
nomina
ÛÛ+ 1
.
ÛÛ1 2#
nominaOtrosDescuentos
ÛÛ2 G
,
ÛÛG H!
nominaTotalIngresos
ÙÙ '
:
ÙÙ' (
nomina
ÙÙ) /
.
ÙÙ/ 0
TotalIngresos
ÙÙ0 =
,
ÙÙ= >#
nominaTotalDescuentos
ıı )
:
ıı) *
nomina
ıı+ 1
.
ıı1 2
TotalDescuentos
ıı2 A
,
ııA B
nominaSueldoNeto
ˆˆ $
:
ˆˆ$ %
nomina
ˆˆ& ,
.
ˆˆ, -

SueldoNeto
ˆˆ- 7
)
˜˜ 
;
˜˜ 
}
¯¯ 
periodo
˙˙ 
.
˙˙ 
PeriodoEstado
˙˙ !
=
˙˙" #
$str
˙˙$ '
;
˙˙' (
await
˚˚ 
_repository
˚˚ 
.
˚˚ $
ActualizarPeriodoAsync
˚˚ 4
(
˚˚4 5
periodo
˚˚5 <
)
˚˚< =
;
˚˚= >
await
˝˝ 
_repository
˝˝ 
.
˝˝ 
SaveChangesAsync
˝˝ .
(
˝˝. /
)
˝˝/ 0
;
˝˝0 1
}
ˇˇ 	
}
ÅÅ 
}ÇÇ Ù
oC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\interfaces\INominaService.cs
	namespace 	
Nomina
 
. 
Application 
. 

interfaces '
{ 
public 

	interface 
INominaService #
{ 
Task 
< 
IEnumerable 
< 

NominaView #
># $
>$ %
ProcesarNominaAsync& 9
(9 :
NominaFiltroRequest: M
requestN U
)U V
;V W
Task 
< 
IEnumerable 
< 
int 
> 
> 
ObtenerAniosAsync 0
(0 1
)1 2
;2 3
Task 
< 
IEnumerable 
< 
int 
> 
> 
ObtenerMesesAsync 0
(0 1
)1 2
;2 3
Task 
< 
IEnumerable 
< 

PeriodoDto #
># $
>$ %
ObtenerPeriodoAsync& 9
(9 :
): ;
;; <
Task 
< 
IEnumerable 
< 
DepartamentoDto (
>( )
>) *%
ObtenerDepartamentosAsync+ D
(D E
)E F
;F G
Task 
< 
IEnumerable 
< 
ContratoDto $
>$ %
>% & 
ObtenerContratoAsync' ;
(; <
)< =
;= >
Task 
CrearNominaAsync 
( 
NominaRequest +
request, 3
)3 4
;4 5
} 
} ∏
dC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\Helpers\Helper.cs
	namespace 	
Nomina
 
. 
Application 
. 
Helpers $
{ 
public		 

class		 
Helper		 
{

 
public 
static 
string 
ObtenerNombreMes -
(- .
int. 1
mes2 5
)5 6
{ 	
return 
mes 
switch 
{ 
$num 
=> 
$str 
, 
$num 
=> 
$str 
, 
$num 
=> 
$str 
, 
$num 
=> 
$str 
, 
$num 
=> 
$str 
, 
$num 
=> 
$str 
, 
$num 
=> 
$str 
, 
$num 
=> 
$str 
, 
$num 
=> 
$str !
,! "
$num 
=> 
$str 
,  
$num 
=> 
$str !
,! "
$num 
=> 
$str !
,! "
_ 
=> 
$str #
} 
; 
} 	
public 
static 
string 
ObtenerNombreEstado 0
(0 1
String1 7
estado8 >
)> ?
{   	
return!! 
estado!! 
switch!!  
{"" 
$str## 
=>## 
$str## 
,##  
$str$$ 
=>$$ 
$str$$ "
,$$" #
_%% 
=>%% 
$str%% 
}&& 
;&& 
}'' 	
public)) 
static)) 
string)) $
ObtenerDescripcionEstado)) 5
())5 6
string))6 <
?))< =
estado))> D
)))D E
=>))F H
estado** 
switch** 
{++ 	
$str,, 
=>,, 
$str,, 
,,, 
$str-- 
=>-- 
$str-- 
,-- 
$str.. 
=>.. 
$str.. 
,..  
_// 
=>// 
$str// 
}00 	
;00	 

}22 
}33 ‰_
uC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\Services\ContratoLaboralService.cs
	namespace 	
Nomina
 
. 
Application 
. 
Services %
{ 
public 

class "
ContratoLaboralService '
:( )#
IContratoLaboralService* A
{ 
private 
readonly &
IContratoLaboralRepository 3
_contratoRepository4 G
;G H
public "
ContratoLaboralService %
(% &&
IContratoLaboralRepository& @
contratoRepositoryA S
)S T
{ 	
_contratoRepository 
=  !
contratoRepository" 4
;4 5
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
ContratoView& 2
>2 3
>3 4
ConsultarContratos5 G
(G H
)H I
{ 	
var 
contrato 
= 
await  
_contratoRepository! 4
.4 5#
ConsultarContratosAsync5 L
(L M
)M N
;N O
return 
contrato 
; 
} 	
public 
async 
Task 
< 
string  
>  !
RegistrarContrato" 3
(3 4
RegistroContratoDto4 G
dtoH K
)K L
{ 	
var 
contrato 
= 
new 
ContratoLaboral .
{   
EmpleadoCodigo!! 
=!!  
dto!!! $
.!!$ %
EmpleadoCodigo!!% 3
,!!3 4
TipoContratoCodigo"" "
=""# $
dto""% (
.""( )
TipoContratoCodigo"") ;
,""; <
ModalidadCodigo## 
=##  !
dto##" %
.##% &
ModalidadCodigo##& 5
,##5 6
JornadaCodigo$$ 
=$$ 
dto$$  #
.$$# $
JornadaCodigo$$$ 1
,$$1 2
UsuarioCodigo%% 
=%% 
dto%%  #
.%%# $
UsuarioCodigo%%$ 1
,%%1 2
ContratoFechaInicio&& #
=&&$ %
dto&&& )
.&&) *
ContratoFechaInicio&&* =
,&&= >
ContratoFechaFin''  
=''! "
dto''# &
.''& '
ContratoFechaFin''' 7
,''7 8
ContratoSalario(( 
=((  !
dto((" %
.((% &
ContratoSalario((& 5
,((5 6
ContratoEstado)) 
=))  
$str))! $
}** 
;**  
ContratoLaboralRules++  
.++  !$
ValidarCoherenciaGeneral++! 9
(++9 :
contrato++: B
)++B C
;++C D 
ContratoLaboralRules,,  
.,,  !
ValidarFechaInicio,,! 3
(,,3 4
contrato,,4 <
),,< =
;,,= > 
ContratoLaboralRules--  
.--  ! 
ValidarSalarioMinimo--! 5
(--5 6
dto--6 9
.--9 :
ContratoSalario--: I
,--I J 
ValidacionesContrato--K _
.--_ `
SALARIO_MINIMO--` n
)--n o
;--o p
var.. 
existeEmpleado.. 
=..  
await..! &
_contratoRepository..' :
...: ; 
ExisteEmpleadoActivo..; O
(..O P
dto..P S
...S T
EmpleadoCodigo..T b
)..b c
;..c d
if// 
(// 
!// 
existeEmpleado// 
)//  
throw00 
new00 
NotFoundException00 +
(00+ ,
$str00, T
)00T U
;00U V
var22 
vigente22 
=22 
await22 
_contratoRepository22  3
.223 4!
ExisteContratoVigente224 I
(22I J
dto22J M
.22M N
EmpleadoCodigo22N \
)22\ ]
;22] ^ 
ContratoLaboralRules33  
.33  !$
ValidarContratoDuplicado33! 9
(339 :
vigente33: A
)33A B
;33B C
await44 
_contratoRepository44 %
.44% &
InsertarContrato44& 6
(446 7
contrato447 ?
)44? @
;44@ A
return55 
$str55 6
;556 7
}66 	
public88 
async88 
Task88 
ModificarContrato88 +
(88+ ,
ContratoLaboralDto88, >
dto88? B
)88B C
{99 	
var:: 
contrato:: 
=:: 
await::  
_contratoRepository::! 4
.::4 5
ObtenerContrato::5 D
(::D E
dto::E H
.::H I
ContratoCodigo::I W
)::W X
;::X Y
if;; 
(;; 
contrato;; 
==;; 
null;;  
);;  !
throw<< 
new<< 
NotFoundException<< +
(<<+ ,
$str<<, E
)<<E F
;<<F G 
ContratoLaboralRules>>  
.>>  !#
ValidarEdicionPorEstado>>! 8
(>>8 9
contrato>>9 A
.>>A B
ContratoEstado>>B P
)>>P Q
;>>Q R
contrato@@ 
.@@ 
TipoContratoCodigo@@ '
=@@( )
dto@@* -
.@@- .
TipoContratoCodigo@@. @
;@@@ A
contratoAA 
.AA 
ModalidadCodigoAA $
=AA% &
dtoAA' *
.AA* +
ModalidadCodigoAA+ :
;AA: ;
contratoBB 
.BB 
JornadaCodigoBB "
=BB# $
dtoBB% (
.BB( )
JornadaCodigoBB) 6
;BB6 7
contratoCC 
.CC 
UsuarioCodigoCC "
=CC# $
dtoCC% (
.CC( )
UsuarioCodigoCC) 6
;CC6 7
contratoDD 
.DD 
ContratoFechaInicioDD (
=DD) *
dtoDD+ .
.DD. /
ContratoFechaInicioDD/ B
;DDB C
contratoEE 
.EE 
ContratoFechaFinEE %
=EE& '
dtoEE( +
.EE+ ,
ContratoFechaFinEE, <
;EE< =
contratoFF 
.FF 
ContratoSalarioFF $
=FF% &
dtoFF' *
.FF* +
ContratoSalarioFF+ :
;FF: ; 
ContratoLaboralRulesGG  
.GG  ! 
ValidarSalarioMinimoGG! 5
(GG5 6
dtoGG6 9
.GG9 :
ContratoSalarioGG: I
,GGI J 
ValidacionesContratoGGK _
.GG_ `
SALARIO_MINIMOGG` n
)GGn o
;GGo p 
ContratoLaboralRulesHH  
.HH  !$
ValidarCoherenciaGeneralHH! 9
(HH9 :
contratoHH: B
)HHB C
;HHC D
awaitII 
_contratoRepositoryII %
.II% &
ModificarContratoII& 7
(II7 8
contratoII8 @
,II@ A
dtoIIB E
.IIE F
MotivoIIF L
)IIL M
;IIM N
}JJ 	
publicLL 
asyncLL 
TaskLL 
EliminarContratoLL *
(LL* +
stringLL+ 1
contratoCodigoLL2 @
)LL@ A
{MM 	
awaitNN 
_contratoRepositoryNN %
.NN% &
EliminarContratoNN& 6
(NN6 7
contratoCodigoNN7 E
)NNE F
;NNF G
}OO 	
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
ContratoLaboralQQ )
>QQ) *
ObtenerContratoQQ+ :
(QQ: ;
stringQQ; A
codigoQQB H
)QQH I
{RR 	
varSS 
contratoSS 
=SS 
awaitSS  
_contratoRepositorySS! 4
.SS4 5
ObtenerContratoSS5 D
(SSD E
codigoSSE K
)SSK L
;SSL M
ifTT 
(TT 
contratoTT 
==TT 
nullTT  
)TT  !
throwUU 
newUU 
NotFoundExceptionUU +
(UU+ ,
$strUU, E
)UUE F
;UUF G
returnVV 
contratoVV 
;VV 
}WW 	
publicXX 
asyncXX 
TaskXX 
<XX 
IEnumerableXX %
<XX% &
ContratoResumenXX& 5
>XX5 6
>XX6 7"
ListarContratosPorTipoXX8 N
(XXN O
)XXO P
=>YY 
awaitYY 
_contratoRepositoryYY (
.YY( )"
ListarContratosPorTipoYY) ?
(YY? @
)YY@ A
;YYA B
public[[ 
async[[ 
Task[[ 
<[[ 
IEnumerable[[ %
<[[% &
ContratoResumen[[& 5
>[[5 6
>[[6 7'
ListarContratosPorModalidad[[8 S
([[S T
)[[T U
=>\\ 
await\\ 
_contratoRepository\\ (
.\\( )'
ListarContratosPorModalidad\\) D
(\\D E
)\\E F
;\\F G
public^^ 
async^^ 
Task^^ 
<^^ 
IEnumerable^^ %
<^^% &
ContratoResumen^^& 5
>^^5 6
>^^6 7%
ListarContratosPorJornada^^8 Q
(^^Q R
)^^R S
=>__ 
await__ 
_contratoRepository__ (
.__( )%
ListarContratosPorJornada__) B
(__B C
)__C D
;__D E
publicaa 
asyncaa 
Taskaa 
<aa 
IEnumerableaa %
<aa% &
ContratoResumenaa& 5
>aa5 6
>aa6 7$
ListarContratosPorEstadoaa8 P
(aaP Q
)aaQ R
{bb 	
varcc 
	contratoscc 
=cc 
awaitcc !
_contratoRepositorycc" 5
.cc5 6$
ListarContratosPorEstadocc6 N
(ccN O
)ccO P
;ccP Q
returnee 
	contratosee 
.ee 
Selectee #
(ee# $
cee$ %
=>ee& (
newee) ,
ContratoResumenee- <
{ff 
Codigogg 
=gg 
cgg 
.gg 
Codigogg !
,gg! "
Descripcionhh 
=hh 
Helperhh $
.hh$ %$
ObtenerDescripcionEstadohh% =
(hh= >
chh> ?
.hh? @
Descripcionhh@ K
)hhK L
}ii 
)ii 
;ii 
}jj 	
publicll 
asyncll 
Taskll 
RegistrarHistorialll ,
(ll, -
HistorialContratoll- >
	historialll? H
)llH I
{mm 	
awaitnn 
_contratoRepositorynn %
.nn% &
RegistrarHistorialnn& 8
(nn8 9
	historialnn9 B
)nnB C
;nnC D
}oo 	
publicpp 
asyncpp 
Taskpp 
<pp 
IEnumerablepp %
<pp% &
HistorialDetallepp& 6
>pp6 7
>pp7 8#
ListarHistorialDetallespp9 P
(ppP Q
)ppQ R
{qq 	
returnrr 
awaitrr 
_contratoRepositoryrr ,
.rr, -#
ListarHistorialDetallesrr- D
(rrD E
)rrE F
;rrF G
}ss 	
publictt 
asynctt 
Tasktt 
SuspenderContratott +
(tt+ ,
stringtt, 2
contratoCodigott3 A
,ttA B
stringttC I
nuevoEstadottJ U
,ttU V
stringttW ]
motivott^ d
)ttd e
{uu 	
awaitvv 
_contratoRepositoryvv %
.vv% &
SuspenderContratovv& 7
(vv7 8
contratoCodigovv8 F
,vvF G
nuevoEstadovvH S
,vvS T
motivovvU [
)vv[ \
;vv\ ]
}ww 	
publicxx	 
asyncxx 
Taskxx 
<xx 
IEnumerablexx &
<xx& '
objectxx' -
>xx- .
>xx. /&
ListarEmpleadosSinContratoxx0 J
(xxJ K
)xxK L
{yy 	
returnzz 
awaitzz 
_contratoRepositoryzz ,
.zz, -&
ListarEmpleadosSinContratozz- G
(zzG H
)zzH I
;zzI J
}{{ 	
}|| 
}}} Œ

vC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\interfaces\IReporteNominaService.cs
	namespace 	
Nomina
 
. 
Application 
. 

interfaces '
{		 
public

 

	interface

 !
IReporteNominaService

 *
{ 
Task 
< 	
List	 
< 
ReporteNominaView 
>  
>  !
GenerarReporteAsync" 5
(5 6
string 
? 
PeriodoCodigo 
, 
string 
? 
departamentoCodigo "
," #
string 
? 
cargoCodigo 
, 
string 
? 
tipoContratoCodigo "
) 
; 
Task 
< 	
byte	 
[ 
] 
> "
GenerarReportePdfAsync '
(' (
string 
? 
PeriodoCodigo 
, 
string 
? 
departamentoCodigo "
," #
string 
? 
cargoCodigo 
, 
string 
? 
tipoContratoCodigo "
) 
; 
} 
} Ä
xC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\interfaces\IContratoLaboralService.cs
	namespace 	
Nomina
 
. 
Application 
. 

Interfaces '
{ 
public		 

	interface		 #
IContratoLaboralService		 ,
{

 
Task 
< 
IEnumerable 
< 
ContratoView %
>% &
>& '
ConsultarContratos( :
(: ;
); <
;< =
Task 
< 
ContratoLaboral 
> 
ObtenerContrato -
(- .
string. 4
codigo5 ;
); <
;< =
Task 
< 
string 
> 
RegistrarContrato &
(& '
RegistroContratoDto' :
dto; >
)> ?
;? @
Task 
ModificarContrato 
( 
ContratoLaboralDto 1
dto2 5
)5 6
;6 7
Task 
EliminarContrato 
( 
string $
contratoCodigo% 3
)3 4
;4 5
Task 
RegistrarHistorial 
(  
HistorialContrato  1
	historial2 ;
); <
;< =
Task 
SuspenderContrato 
( 
string %
contratoCodigo& 4
,4 5
string6 <
nuevoEstado= H
,H I
stringJ P
motivoQ W
)W X
;X Y
Task 
< 
IEnumerable 
< 
ContratoResumen (
>( )
>) *"
ListarContratosPorTipo+ A
(A B
)B C
;C D
Task 
< 
IEnumerable 
< 
ContratoResumen (
>( )
>) *'
ListarContratosPorModalidad+ F
(F G
)G H
;H I
Task 
< 
IEnumerable 
< 
ContratoResumen (
>( )
>) *%
ListarContratosPorJornada+ D
(D E
)E F
;F G
Task 
< 
IEnumerable 
< 
ContratoResumen (
>( )
>) *$
ListarContratosPorEstado+ C
(C D
)D E
;E F
Task 
< 
IEnumerable 
< 
HistorialDetalle )
>) *
>* +#
ListarHistorialDetalles, C
(C D
)D E
;E F
Task 
< 
IEnumerable 
< 
object 
>  
>  !&
ListarEmpleadosSinContrato" <
(< =
)= >
;> ?
} 
} ®™
pC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\Helpers\PdfGeneratorHelper.cs
	namespace

 	
Nomina


 
.

 
Application

 
.

 
Helpers

 $
{ 
public 

static 
class 
PdfGeneratorHelper *
{ 
public 
static 
byte 
[ 
] 
GenerarNominaPdf -
(- .
List. 2
<2 3
ReporteNominaView3 D
>D E
dataF J
,J K
DateTimeL T
fechaInicioU `
,` a
DateTimeb j
fechaFink s
)s t
{ 	
var 
document 
= 
Document #
.# $
Create$ *
(* +
	container+ 4
=>5 7
{ 
	container 
. 
Page 
( 
page #
=>$ &
{ 
page 
. 
Size 
( 
	PageSizes '
.' (
A4( *
.* +
	Landscape+ 4
(4 5
)5 6
)6 7
;7 8
page 
. 
Margin 
(  
$num  "
)" #
;# $
page 
. 
DefaultTextStyle )
() *
x* +
=>, .
x/ 0
.0 1
FontSize1 9
(9 :
$num: <
)< =
)= >
;> ?
page 
. 
Header 
(  
)  !
. 
Column 
(  
column  &
=>' )
{ 
column "
." #
Item# '
(' (
)( )
.) *
Text* .
(. /
$str/ N
)N O
.O P
StyleP U
(U V
	TextStyleV _
._ `
Default` g
.g h
FontSizeh p
(p q
$numq s
)s t
.t u
Boldu y
(y z
)z {
){ |
.| }
AlignCenter	} à
(
à â
)
â ä
;
ä ã
column "
." #
Item# '
(' (
)( )
.) *
Text* .
(. /
$"/ 1
$str1 :
{: ;
fechaInicio; F
:F G
$strG Q
}Q R
$strR U
{U V
fechaFinV ^
:^ _
$str_ i
}i j
"j k
)k l
.l m
AlignCenterm x
(x y
)y z
;z {
column "
." #
Item# '
(' (
)( )
.) *

PaddingTop* 4
(4 5
$num5 7
)7 8
;8 9
} 
) 
; 
page 
. 
Content  
(  !
)! "
.   
PaddingVertical   (
(  ( )
$num  ) *
)  * +
.!! 
Table!! 
(!! 
table!! $
=>!!% '
{"" 
table## !
.##! "
ColumnsDefinition##" 3
(##3 4
columns##4 ;
=>##< >
{$$ 
columns%%  '
.%%' (
RelativeColumn%%( 6
(%%6 7
$num%%7 ;
)%%; <
;%%< =
columns&&  '
.&&' (
RelativeColumn&&( 6
(&&6 7
$num&&7 8
)&&8 9
;&&9 :
columns''  '
.''' (
RelativeColumn''( 6
(''6 7
$num''7 8
)''8 9
;''9 :
columns((  '
.((' (
RelativeColumn((( 6
(((6 7
$num((7 8
)((8 9
;((9 :
columns))  '
.))' (
RelativeColumn))( 6
())6 7
$num))7 8
)))8 9
;))9 :
columns**  '
.**' (
RelativeColumn**( 6
(**6 7
$num**7 8
)**8 9
;**9 :
columns++  '
.++' (
RelativeColumn++( 6
(++6 7
$num++7 8
)++8 9
;++9 :
columns,,  '
.,,' (
RelativeColumn,,( 6
(,,6 7
$num,,7 8
),,8 9
;,,9 :
columns--  '
.--' (
RelativeColumn--( 6
(--6 7
$num--7 8
)--8 9
;--9 :
columns..  '
...' (
RelativeColumn..( 6
(..6 7
$num..7 8
)..8 9
;..9 :
columns//  '
.//' (
RelativeColumn//( 6
(//6 7
$num//7 8
)//8 9
;//9 :
columns00  '
.00' (
RelativeColumn00( 6
(006 7
$num007 8
)008 9
;009 :
columns11  '
.11' (
RelativeColumn11( 6
(116 7
$num117 8
)118 9
;119 :
columns22  '
.22' (
RelativeColumn22( 6
(226 7
$num227 8
)228 9
;229 :
}33 
)33 
;33 
table55 !
.55! "
Header55" (
(55( )
header55) /
=>550 2
{66 
	TextStyle77  )
headerStyle77* 5
=776 7
	TextStyle778 A
.77A B
Default77B I
.77I J
Bold77J N
(77N O
)77O P
.77P Q
BackgroundColor77Q `
(77` a
Colors77a g
.77g h
Grey77h l
.77l m
Lighten377m u
)77u v
;77v w
header99  &
.99& '
Cell99' +
(99+ ,
)99, -
.99- .
BorderBottom99. :
(99: ;
$num99; <
)99< =
.99= >
Padding99> E
(99E F
$num99F G
)99G H
.99H I
Text99I M
(99M N
$str99N V
)99V W
.99W X
Style99X ]
(99] ^
headerStyle99^ i
)99i j
;99j k
header::  &
.::& '
Cell::' +
(::+ ,
)::, -
.::- .
BorderBottom::. :
(::: ;
$num::; <
)::< =
.::= >
Padding::> E
(::E F
$num::F G
)::G H
.::H I
Text::I M
(::M N
$str::N X
)::X Y
.::Y Z
Style::Z _
(::_ `
headerStyle::` k
)::k l
;::l m
header;;  &
.;;& '
Cell;;' +
(;;+ ,
);;, -
.;;- .
BorderBottom;;. :
(;;: ;
$num;;; <
);;< =
.;;= >
Padding;;> E
(;;E F
$num;;F G
);;G H
.;;H I
Text;;I M
(;;M N
$str;;N \
);;\ ]
.;;] ^
Style;;^ c
(;;c d
headerStyle;;d o
);;o p
;;;p q
header<<  &
.<<& '
Cell<<' +
(<<+ ,
)<<, -
.<<- .
BorderBottom<<. :
(<<: ;
$num<<; <
)<<< =
.<<= >
Padding<<> E
(<<E F
$num<<F G
)<<G H
.<<H I
Text<<I M
(<<M N
$str<<N \
)<<\ ]
.<<] ^
Style<<^ c
(<<c d
headerStyle<<d o
)<<o p
.<<p q

AlignRight<<q {
(<<{ |
)<<| }
;<<} ~
header==  &
.==& '
Cell==' +
(==+ ,
)==, -
.==- .
BorderBottom==. :
(==: ;
$num==; <
)==< =
.=== >
Padding==> E
(==E F
$num==F G
)==G H
.==H I
Text==I M
(==M N
$str==N b
)==b c
.==c d
Style==d i
(==i j
headerStyle==j u
)==u v
.==v w

AlignRight	==w Å
(
==Å Ç
)
==Ç É
;
==É Ñ
header>>  &
.>>& '
Cell>>' +
(>>+ ,
)>>, -
.>>- .
BorderBottom>>. :
(>>: ;
$num>>; <
)>>< =
.>>= >
Padding>>> E
(>>E F
$num>>F G
)>>G H
.>>H I
Text>>I M
(>>M N
$str>>N \
)>>\ ]
.>>] ^
Style>>^ c
(>>c d
headerStyle>>d o
)>>o p
.>>p q

AlignRight>>q {
(>>{ |
)>>| }
;>>} ~
header??  &
.??& '
Cell??' +
(??+ ,
)??, -
.??- .
BorderBottom??. :
(??: ;
$num??; <
)??< =
.??= >
Padding??> E
(??E F
$num??F G
)??G H
.??H I
Text??I M
(??M N
$str??N c
)??c d
.??d e
Style??e j
(??j k
headerStyle??k v
)??v w
.??w x

AlignRight	??x Ç
(
??Ç É
)
??É Ñ
;
??Ñ Ö
header@@  &
.@@& '
Cell@@' +
(@@+ ,
)@@, -
.@@- .
BorderBottom@@. :
(@@: ;
$num@@; <
)@@< =
.@@= >
Padding@@> E
(@@E F
$num@@F G
)@@G H
.@@H I
Text@@I M
(@@M N
$str@@N ^
)@@^ _
.@@_ `
Style@@` e
(@@e f
headerStyle@@f q
)@@q r
.@@r s

AlignRight@@s }
(@@} ~
)@@~ 
;	@@ Ä
headerAA  &
.AA& '
CellAA' +
(AA+ ,
)AA, -
.AA- .
BorderBottomAA. :
(AA: ;
$numAA; <
)AA< =
.AA= >
PaddingAA> E
(AAE F
$numAAF G
)AAG H
.AAH I
TextAAI M
(AAM N
$strAAN ]
)AA] ^
.AA^ _
StyleAA_ d
(AAd e
headerStyleAAe p
)AAp q
.AAq r

AlignRightAAr |
(AA| }
)AA} ~
;AA~ 
headerBB  &
.BB& '
CellBB' +
(BB+ ,
)BB, -
.BB- .
BorderBottomBB. :
(BB: ;
$numBB; <
)BB< =
.BB= >
PaddingBB> E
(BBE F
$numBBF G
)BBG H
.BBH I
TextBBI M
(BBM N
$strBBN V
)BBV W
.BBW X
StyleBBX ]
(BB] ^
headerStyleBB^ i
)BBi j
.BBj k

AlignRightBBk u
(BBu v
)BBv w
;BBw x
headerCC  &
.CC& '
CellCC' +
(CC+ ,
)CC, -
.CC- .
BorderBottomCC. :
(CC: ;
$numCC; <
)CC< =
.CC= >
PaddingCC> E
(CCE F
$numCCF G
)CCG H
.CCH I
TextCCI M
(CCM N
$strCCN W
)CCW X
.CCX Y
StyleCCY ^
(CC^ _
headerStyleCC_ j
)CCj k
.CCk l

AlignRightCCl v
(CCv w
)CCw x
;CCx y
headerDD  &
.DD& '
CellDD' +
(DD+ ,
)DD, -
.DD- .
BorderBottomDD. :
(DD: ;
$numDD; <
)DD< =
.DD= >
PaddingDD> E
(DDE F
$numDDF G
)DDG H
.DDH I
TextDDI M
(DDM N
$strDDN [
)DD[ \
.DD\ ]
StyleDD] b
(DDb c
headerStyleDDc n
)DDn o
.DDo p

AlignRightDDp z
(DDz {
)DD{ |
;DD| }
headerEE  &
.EE& '
CellEE' +
(EE+ ,
)EE, -
.EE- .
BorderBottomEE. :
(EE: ;
$numEE; <
)EE< =
.EE= >
PaddingEE> E
(EEE F
$numEEF G
)EEG H
.EEH I
TextEEI M
(EEM N
$strEEN `
)EE` a
.EEa b
StyleEEb g
(EEg h
headerStyleEEh s
)EEs t
.EEt u

AlignRightEEu 
(	EE Ä
)
EEÄ Å
;
EEÅ Ç
headerFF  &
.FF& '
CellFF' +
(FF+ ,
)FF, -
.FF- .
BorderBottomFF. :
(FF: ;
$numFF; <
)FF< =
.FF= >
PaddingFF> E
(FFE F
$numFFF G
)FFG H
.FFH I
TextFFI M
(FFM N
$strFFN [
)FF[ \
.FF\ ]
StyleFF] b
(FFb c
headerStyleFFc n
)FFn o
.FFo p

AlignRightFFp z
(FFz {
)FF{ |
;FF| }
}GG 
)GG 
;GG 
foreachII #
(II$ %
varII% (
itemII) -
inII. 0
dataII1 5
)II5 6
{JJ 
stringKK  &
formatoMonedaKK' 4
=KK5 6
$strKK7 ;
;KK; <
tableMM  %
.MM% &
CellMM& *
(MM* +
)MM+ ,
.MM, -
BorderBottomMM- 9
(MM9 :
$numMM: ;
)MM; <
.MM< =
PaddingMM= D
(MMD E
$numMME F
)MMF G
.MMG H
TextMMH L
(MML M
itemMMM Q
.MMQ R
CodigoMMR X
)MMX Y
;MMY Z
tableNN  %
.NN% &
CellNN& *
(NN* +
)NN+ ,
.NN, -
BorderBottomNN- 9
(NN9 :
$numNN: ;
)NN; <
.NN< =
PaddingNN= D
(NND E
$numNNE F
)NNF G
.NNG H
TextNNH L
(NNL M
itemNNM Q
.NNQ R
EmpleadoNNR Z
)NNZ [
;NN[ \
tableOO  %
.OO% &
CellOO& *
(OO* +
)OO+ ,
.OO, -
BorderBottomOO- 9
(OO9 :
$numOO: ;
)OO; <
.OO< =
PaddingOO= D
(OOD E
$numOOE F
)OOF G
.OOG H
TextOOH L
(OOL M
itemOOM Q
.OOQ R
SalarioBaseOOR ]
.OO] ^
ToStringOO^ f
(OOf g
formatoMonedaOOg t
)OOt u
)OOu v
.OOv w

AlignRight	OOw Å
(
OOÅ Ç
)
OOÇ É
;
OOÉ Ñ
tablePP  %
.PP% &
CellPP& *
(PP* +
)PP+ ,
.PP, -
BorderBottomPP- 9
(PP9 :
$numPP: ;
)PP; <
.PP< =
PaddingPP= D
(PPD E
$numPPE F
)PPF G
.PPG H
TextPPH L
(PPL M
itemPPM Q
.PPQ R
HorasExtrasPPR ]
.PP] ^
ToStringPP^ f
(PPf g
)PPg h
)PPh i
.PPi j

AlignRightPPj t
(PPt u
)PPu v
;PPv w
tableQQ  %
.QQ% &
CellQQ& *
(QQ* +
)QQ+ ,
.QQ, -
BorderBottomQQ- 9
(QQ9 :
$numQQ: ;
)QQ; <
.QQ< =
PaddingQQ= D
(QQD E
$numQQE F
)QQF G
.QQG H
TextQQH L
(QQL M
itemQQM Q
.QQQ R
MontoHorasExtrasQQR b
.QQb c
ToStringQQc k
(QQk l
formatoMonedaQQl y
)QQy z
)QQz {
.QQ{ |

AlignRight	QQ| Ü
(
QQÜ á
)
QQá à
;
QQà â
tableRR  %
.RR% &
CellRR& *
(RR* +
)RR+ ,
.RR, -
BorderBottomRR- 9
(RR9 :
$numRR: ;
)RR; <
.RR< =
PaddingRR= D
(RRD E
$numRRE F
)RRF G
.RRG H
TextRRH L
(RRL M
itemRRM Q
.RRQ R
BonificacionRRR ^
.RR^ _
ToStringRR_ g
(RRg h
formatoMonedaRRh u
)RRu v
)RRv w
.RRw x

AlignRight	RRx Ç
(
RRÇ É
)
RRÉ Ñ
;
RRÑ Ö
tableSS  %
.SS% &
CellSS& *
(SS* +
)SS+ ,
.SS, -
BorderBottomSS- 9
(SS9 :
$numSS: ;
)SS; <
.SS< =
PaddingSS= D
(SSD E
$numSSE F
)SSF G
.SSG H
TextSSH L
(SSL M
itemSSM Q
.SSQ R
AsignacionFamiliarSSR d
.SSd e
ToStringSSe m
(SSm n
formatoMonedaSSn {
)SS{ |
)SS| }
.SS} ~

AlignRight	SS~ à
(
SSà â
)
SSâ ä
;
SSä ã
tableTT  %
.TT% &
CellTT& *
(TT* +
)TT+ ,
.TT, -
BorderBottomTT- 9
(TT9 :
$numTT: ;
)TT; <
.TT< =
PaddingTT= D
(TTD E
$numTTE F
)TTF G
.TTG H
TextTTH L
(TTL M
itemTTM Q
.TTQ R
TotalIngresosTTR _
.TT_ `
ToStringTT` h
(TTh i
formatoMonedaTTi v
)TTv w
)TTw x
.TTx y

AlignRight	TTy É
(
TTÉ Ñ
)
TTÑ Ö
;
TTÖ Ü
tableUU  %
.UU% &
CellUU& *
(UU* +
)UU+ ,
.UU, -
BorderBottomUU- 9
(UU9 :
$numUU: ;
)UU; <
.UU< =
PaddingUU= D
(UUD E
$numUUE F
)UUF G
.UUG H
TextUUH L
(UUL M
itemUUM Q
.UUQ R
DescPensionUUR ]
.UU] ^
ToStringUU^ f
(UUf g
formatoMonedaUUg t
)UUt u
)UUu v
.UUv w

AlignRight	UUw Å
(
UUÅ Ç
)
UUÇ É
;
UUÉ Ñ
tableVV  %
.VV% &
CellVV& *
(VV* +
)VV+ ,
.VV, -
BorderBottomVV- 9
(VV9 :
$numVV: ;
)VV; <
.VV< =
PaddingVV= D
(VVD E
$numVVE F
)VVF G
.VVG H
TextVVH L
(VVL M
itemVVM Q
.VVQ R
IR5taVVR W
.VVW X
ToStringVVX `
(VV` a
formatoMonedaVVa n
)VVn o
)VVo p
.VVp q

AlignRightVVq {
(VV{ |
)VV| }
;VV} ~
tableWW  %
.WW% &
CellWW& *
(WW* +
)WW+ ,
.WW, -
BorderBottomWW- 9
(WW9 :
$numWW: ;
)WW; <
.WW< =
PaddingWW= D
(WWD E
$numWWE F
)WWF G
.WWG H
TextWWH L
(WWL M
itemWWM Q
.WWQ R
EssaludWWR Y
.WWY Z
ToStringWWZ b
(WWb c
formatoMonedaWWc p
)WWp q
)WWq r
.WWr s

AlignRightWWs }
(WW} ~
)WW~ 
;	WW Ä
tableXX  %
.XX% &
CellXX& *
(XX* +
)XX+ ,
.XX, -
BorderBottomXX- 9
(XX9 :
$numXX: ;
)XX; <
.XX< =
PaddingXX= D
(XXD E
$numXXE F
)XXF G
.XXG H
TextXXH L
(XXL M
itemXXM Q
.XXQ R
	OtrosDescXXR [
.XX[ \
ToStringXX\ d
(XXd e
formatoMonedaXXe r
)XXr s
)XXs t
.XXt u

AlignRightXXu 
(	XX Ä
)
XXÄ Å
;
XXÅ Ç
tableYY  %
.YY% &
CellYY& *
(YY* +
)YY+ ,
.YY, -
BorderBottomYY- 9
(YY9 :
$numYY: ;
)YY; <
.YY< =
PaddingYY= D
(YYD E
$numYYE F
)YYF G
.YYG H
TextYYH L
(YYL M
itemYYM Q
.YYQ R
TotalDescuentosYYR a
.YYa b
ToStringYYb j
(YYj k
formatoMonedaYYk x
)YYx y
)YYy z
.YYz {

AlignRight	YY{ Ö
(
YYÖ Ü
)
YYÜ á
;
YYá à
tableZZ  %
.ZZ% &
CellZZ& *
(ZZ* +
)ZZ+ ,
.ZZ, -
BorderBottomZZ- 9
(ZZ9 :
$numZZ: ;
)ZZ; <
.ZZ< =
PaddingZZ= D
(ZZD E
$numZZE F
)ZZF G
.ZZG H
TextZZH L
(ZZL M
itemZZM Q
.ZZQ R

SueldoNetoZZR \
.ZZ\ ]
ToStringZZ] e
(ZZe f
formatoMonedaZZf s
)ZZs t
)ZZt u
.ZZu v

AlignRight	ZZv Ä
(
ZZÄ Å
)
ZZÅ Ç
;
ZZÇ É
}\\ 
}]] 
)]] 
;]] 
page__ 
.__ 
Footer__ 
(__  
)__  !
.`` 
AlignCenter`` $
(``$ %
)``% &
.aa 
Textaa 
(aa 
xaa 
=>aa  "
{bb 
xcc 
.cc 
Spancc "
(cc" #
$strcc# ,
)cc, -
.cc- .
FontSizecc. 6
(cc6 7
$numcc7 8
)cc8 9
;cc9 :
xdd 
.dd 
CurrentPageNumberdd /
(dd/ 0
)dd0 1
.dd1 2
FontSizedd2 :
(dd: ;
$numdd; <
)dd< =
;dd= >
xee 
.ee 
Spanee "
(ee" #
$stree# )
)ee) *
.ee* +
FontSizeee+ 3
(ee3 4
$numee4 5
)ee5 6
;ee6 7
xff 
.ff 

TotalPagesff (
(ff( )
)ff) *
.ff* +
FontSizeff+ 3
(ff3 4
$numff4 5
)ff5 6
;ff6 7
}gg 
)gg 
;gg 
}hh 
)hh 
;hh 
}ii 
)ii 
;ii 
returnkk 
documentkk 
.kk 
GeneratePdfkk '
(kk' (
)kk( )
;kk) *
}ll 	
}mm 
}nn À
pC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\ReporteNominaResponse.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
{ 
public

 

class

 !
ReporteNominaResponse

 &
{ 
public 
string 
NominaCodigo "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
string 
EmpleadoApellido &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
null7 ;
!; <
;< =
public 
string 
EmpleadoNombre $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
public 
string 
DepartamentoNombre (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
public 
string 
CargoNombre !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
public 
int 
PeriodoAnio 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 

PeriodoMes 
{ 
get  #
;# $
set% (
;( )
}* +
public 
decimal 
ContratoSalario &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
decimal 
NominaHorasExtras (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
decimal 
NominaBonificacion )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
decimal 
NominaDescuentos '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
decimal 
NominaSueldoNeto '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
NominaEstado "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
DateTime $
NominaFechaProcesamiento 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
} 
}   ê	
oC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\ReporteNominaRequest.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
{		 
public

 

class

  
ReporteNominaRequest

 %
{ 
[ 	
Required	 
] 
public 
string 
PeriodoCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
null4 8
!8 9
;9 :
public 
string 
? 
DepartamentoCodigo )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
string 
? 
CargoCodigo "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
TipoContratoCodigo )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} ƒ
nC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\registroContratoDTO.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
{ 
public 

class 
RegistroContratoDto $
{ 
public 
string 
EmpleadoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
string5 ;
.; <
Empty< A
;A B
public 
string 
TipoContratoCodigo (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
string9 ?
.? @
Empty@ E
;E F
public 
string 
ModalidadCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
string6 <
.< =
Empty= B
;B C
public		 
string		 
JornadaCodigo		 #
{		$ %
get		& )
;		) *
set		+ .
;		. /
}		0 1
=		2 3
string		4 :
.		: ;
Empty		; @
;		@ A
public

 
string

 
UsuarioCodigo

 #
{

$ %
get

& )
;

) *
set

+ .
;

. /
}

0 1
=

2 3
string

4 :
.

: ;
Empty

; @
;

@ A
public 
DateTime 
? 
ContratoFechaInicio ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
DateTime 
? 
ContratoFechaFin )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
decimal 
ContratoSalario &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} º
pC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\ProcesarNominaRequest.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
{		 
public

 

class

 !
ProcesarNominaRequest

 &
{ 
public 
int 
	IdPeriodo 
{ 
get "
;" #
set$ '
;' (
}) *
public 
DateTime 
FechaProceso $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
int 
	UsuarioId 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} £
iC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\nuevaNominadto.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
{ 
public		 

class		 
NuevaNominaDto		 
{

 
public 
string 
ContratoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
$str5 7
;7 8
public 
string 
PeriodoCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
$str4 6
;6 7
public 
int 
nominaHorasExtras $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
decimal "
nominaMontoHorasExtras -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
decimal 
Bonificaciones %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
decimal $
nominaAsignacionFamiliar /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
decimal "
nominaDescuentoPension -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
decimal  
nominaDescuentoIR5ta +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
decimal 
nominaAporteEssalud *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
decimal !
nominaOtrosDescuentos ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
decimal 
TotalIngresos $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
decimal 
TotalDescuentos &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
decimal 

SueldoNeto !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} ≠
sC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\NominaPeriodo\PeriodoDTO.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
.! "
NominaPeriodo" /
{ 
public		 

class		 

PeriodoDto		 
{

 
public 
string 
PeriodoCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
null4 8
!8 9
;9 :
public 
string 
PeriodoDescripcion (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
public 
string 
PeriodoEstado #
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
} 
} É
vC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\NominaPeriodo\NominaRequest.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
.! "
NominaPeriodo" /
{ 
public		 

class		 
NominaRequest		 
{

 
public 
string 
PeriodoCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
string4 :
.: ;
Empty; @
;@ A
} 
}  
|C:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\NominaPeriodo\NominaFiltroRequest.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
.! "
NominaPeriodo" /
{ 
public		 

class		 
NominaFiltroRequest		 $
{

 
public 
string 
? 
CodigoPeriodo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ‹
xC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\NominaPeriodo\DepartamentoDTO.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
.! "
NominaPeriodo" /
{ 
public		 

class		 
DepartamentoDto		  
{

 
public 
string 
DepartamentoCodigo (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
public 
string 
DepartamentoNombre (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
} 
} —
tC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\NominaPeriodo\ContratoDTO.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
.! "
NominaPeriodo" /
{ 
public		 

class		 
ContratoDto		 
{

 
public 
string 
ContratoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
public 
string 
EmpleadoDescripcion )
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
} 
} „
mC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\ContratoLaboralDTO.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
{ 
public 

class 
ContratoLaboralDto #
{ 
public 
string 
ContratoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
string5 ;
.; <
Empty< A
;A B
public 
string 
EmpleadoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
string5 ;
.; <
Empty< A
;A B
public		 
string		 
TipoContratoCodigo		 (
{		) *
get		+ .
;		. /
set		0 3
;		3 4
}		5 6
=		7 8
string		9 ?
.		? @
Empty		@ E
;		E F
public

 
string

 
ModalidadCodigo

 %
{

& '
get

( +
;

+ ,
set

- 0
;

0 1
}

2 3
=

4 5
string

6 <
.

< =
Empty

= B
;

B C
public 
string 
JornadaCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
string4 :
.: ;
Empty; @
;@ A
public 
string 
UsuarioCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
string4 :
.: ;
Empty; @
;@ A
public 
DateTime 
? 
ContratoFechaInicio ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
DateTime 
? 
ContratoFechaFin )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
decimal 
ContratoSalario &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
ContratoEstado $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
$str5 8
;8 9
public 
string 
Motivo 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
} 
} Û
fC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Application\DTOs\ApiResponse.cs
	namespace 	
Nomina
 
. 
Application 
. 
DTOs !
{ 
public		 

class		 
ApiResponse		 
<		 
T		 
>		 
{

 
public 
int 

StatusCode 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
Success 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
public 
T 
? 
Data 
{ 
get 
; 
set !
;! "
}# $
public 
ApiResponse 
( 
int 

statusCode )
,) *
bool+ /
success0 7
,7 8
string9 ?
message@ G
,G H
TI J
?J K
dataL P
=Q R
defaultS Z
)Z [
{ 	

StatusCode 
= 

statusCode #
;# $
Success 
= 
success 
; 
Message 
= 
message 
; 
Data 
= 
data 
; 
} 	
} 
} 