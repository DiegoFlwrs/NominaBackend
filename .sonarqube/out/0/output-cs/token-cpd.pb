ÏT
cC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\rules\ReglasNomina.cs
	namespace 	
Nomina
 
. 
Domain 
. 
rules 
{ 
public		 

static		 
class		 
ReglasNomina		 $
{

 
public 
static 
decimal &
CalcularAsignacionFamiliar 8
(8 9
bool9 =

tieneHijos> H
,H I
decimalJ Q%
remuneracionMinimaVigenteR k
)k l
{ 	
return 
Math 
. 
Round 
( 

tieneHijos (
?) *%
remuneracionMinimaVigente+ D
*E F
$numG L
:M N
$numO Q
,Q R
$numS T
,T U
MidpointRoundingV f
.f g
AwayFromZerog s
)s t
;t u
} 	
public 
static 
decimal #
CalcularPagoHorasExtras 5
(5 6
decimal6 =
salarioBase> I
,I J
decimalK R
horasExtrasS ^
)^ _
{ 	
if 
( 
horasExtras 
<= 
$num  
)  !
return" (
$num) +
;+ ,
decimal 

tarifaHora 
=  
salarioBase! ,
/- .
$num/ 3
;3 4
decimal 
horasNormales !
=" #
Math$ (
.( )
Min) ,
(, -
horasExtras- 8
,8 9
$num: ;
); <
;< =
decimal 
horasAdicionales $
=% &
Math' +
.+ ,
Max, /
(/ 0
horasExtras0 ;
-< =
$num> ?
,? @
$numA B
)B C
;C D
decimal 
pagoNormales  
=! "
horasNormales# 0
*1 2

tarifaHora3 =
*> ?
$num@ E
;E F
decimal 
pagoAdicionales #
=$ %
horasAdicionales& 6
*7 8

tarifaHora9 C
*D E
$numF K
;K L
return 
Math 
. 
Round 
( 
pagoNormales *
++ ,
pagoAdicionales- <
,< =
$num> ?
,? @
MidpointRoundingA Q
.Q R
AwayFromZeroR ^
)^ _
;_ `
} 	
public 
static 
decimal 
CalcularSueldoBruto 1
(1 2
decimal2 9
sueldoBasico: F
,F G
decimalH O
asignacionFamiliarP b
,b c
decimald k
pagoHorasExtrasl {
,{ |
decimal	} „
bonificacion
… ‘
)
‘ ’
{   	
return!! 
Math!! 
.!! 
Round!! 
(!! 
sueldoBasico!! *
+!!+ ,
asignacionFamiliar!!- ?
+!!@ A
pagoHorasExtras!!B Q
+!!R S
bonificacion!!T `
,!!` a
$num!!b c
,!!c d
MidpointRounding!!e u
.!!u v
AwayFromZero	!!v ‚
)
!!‚ ƒ
;
!!ƒ „
}"" 	
public$$ 
static$$ 
decimal$$ 
CalcularEssalud$$ -
($$- .
decimal$$. 5
sueldoBruto$$6 A
)$$A B
{%% 	
return&& 
Math&& 
.&& 
Round&& 
(&& 
sueldoBruto&& )
*&&* +
$num&&, 1
,&&1 2
$num&&3 4
,&&4 5
MidpointRounding&&6 F
.&&F G
AwayFromZero&&G S
)&&S T
;&&T U
}'' 	
public)) 
static)) 
decimal)) $
CalcularDescuentoPension)) 6
())6 7
string))7 =
tipoPension))> I
,))I J
decimal))K R
sueldoBruto))S ^
,))^ _
decimal))` g
porcetajePension))h x
)))x y
{** 	
tipoPension++ 
=++ 
tipoPension++ %
?++% &
.++& '
ToUpper++' .
(++. /
)++/ 0
??++1 3
$str++4 6
;++6 7
decimal-- 
	resultado-- 
=-- 
$num--  "
;--" #
if// 
(// 
tipoPension// 
==// 
$str// $
)//$ %
{00 
	resultado11 
=11 
sueldoBruto11 '
*11( )
porcetajePension11* :
;11: ;
}22 
else33 
if33 
(33 
tipoPension33  
==33! #
$str33$ )
)33) *
{44 
decimal55 
aporte55 
=55  
sueldoBruto55! ,
*55- .
$num55/ 4
;554 5
decimal66 
descuentoSeguro66 '
=66( )
sueldoBruto66* 5
*666 7
porcetajePension668 H
;66H I
	resultado77 
=77 
aporte77 "
+77# $
descuentoSeguro77% 4
;774 5
}88 
return:: 
Math:: 
.:: 
Round:: 
(:: 
	resultado:: '
,::' (
$num::) *
,::* +
MidpointRounding::, <
.::< =
AwayFromZero::= I
)::I J
;::J K
};; 	
public== 
static== 
decimal== 
CalcularRentaQuinta== 1
(==1 2
decimal==2 9
sueldoAnual==: E
,==E F
decimal==G N
UIT==O R
)==R S
{>> 	
decimal?? 
	deduccion?? 
=?? 
UIT??  #
*??$ %
$num??& '
;??' (
decimal@@ 
	rentaNeta@@ 
=@@ 
sueldoAnual@@  +
-@@, -
	deduccion@@. 7
;@@7 8
ifAA 
(AA 
	rentaNetaAA 
<=AA 
$numAA 
)AA 
returnBB 
$numBB 
;BB 
decimalDD 
impuestoDD 
=DD 
$numDD !
;DD! "
decimalFF 
[FF 
]FF 
tramosFF 
=FF 
{FF  
UITFF! $
*FF% &
$numFF' (
,FF( )
UITFF* -
*FF. /
$numFF0 2
,FF2 3
UITFF4 7
*FF8 9
$numFF: <
,FF< =
UITFF> A
*FFB C
$numFFD F
}FFG H
;FFH I
decimalGG 
[GG 
]GG 
tasasGG 
=GG 
{GG 
$numGG  %
,GG% &
$numGG' ,
,GG, -
$numGG. 3
,GG3 4
$numGG5 :
,GG: ;
$numGG< A
}GGB C
;GGC D
decimalII 
restanteII 
=II 
	rentaNetaII (
;II( )
decimalJJ 
anteriorJJ 
=JJ 
$numJJ  
;JJ  !
forLL 
(LL 
intLL 
iLL 
=LL 
$numLL 
;LL 
iLL 
<LL 
tasasLL  %
.LL% &
LengthLL& ,
;LL, -
iLL. /
++LL/ 1
)LL1 2
{MM 
decimalNN 
limiteNN 
=NN  
iNN! "
<NN# $
tramosNN% +
.NN+ ,
LengthNN, 2
?NN3 4
tramosNN5 ;
[NN; <
iNN< =
]NN= >
-NN? @
anteriorNNA I
:NNJ K
decimalNNL S
.NNS T
MaxValueNNT \
;NN\ ]
decimalOO 
baseImponibleOO %
=OO& '
MathOO( ,
.OO, -
MinOO- 0
(OO0 1
restanteOO1 9
,OO9 :
limiteOO; A
)OOA B
;OOB C
impuestoQQ 
+=QQ 
baseImponibleQQ )
*QQ* +
tasasQQ, 1
[QQ1 2
iQQ2 3
]QQ3 4
;QQ4 5
restanteRR 
-=RR 
baseImponibleRR )
;RR) *
ifSS 
(SS 
restanteSS 
<=SS 
$numSS  !
)SS! "
breakSS# (
;SS( )
anteriorUU 
=UU 
tramosUU !
[UU! "
MathUU" &
.UU& '
MinUU' *
(UU* +
iUU+ ,
,UU, -
tramosUU. 4
.UU4 5
LengthUU5 ;
-UU< =
$numUU> ?
)UU? @
]UU@ A
;UUA B
}VV 
returnXX 
MathXX 
.XX 
RoundXX 
(XX 
impuestoXX &
/XX' (
$numXX) +
,XX+ ,
$numXX- .
,XX. /
MidpointRoundingXX0 @
.XX@ A
AwayFromZeroXXA M
)XXM N
;XXN O
}YY 	
public[[ 
static[[ 
decimal[[ .
"CalcularTotalDescuentosAdicionales[[ @
([[@ A
decimal[[A H
descuentosPension[[I Z
,[[Z [
decimal[[\ c
impuestoRenta[[d q
,[[q r
decimal[[s z
descuentoEssalud	[[{ ‹
,
[[‹ Œ
decimal
[[ ”
otrosDescuentos
[[• ¤
)
[[¤ ¥
{\\ 	
return]] 
Math]] 
.]] 
Round]] 
(]] 
descuentosPension]] /
+]]0 1
impuestoRenta]]2 ?
+]]@ A
descuentoEssalud]]B R
+]]S T
otrosDescuentos]]U d
,]]d e
$num]]f g
,]]g h
MidpointRounding]]i y
.]]y z
AwayFromZero	]]z †
)
]]† ‡
;
]]‡ ˆ
}^^ 	
public`` 
static`` 
decimal`` 
CalcularSueldoNeto`` 0
(``0 1
decimal``1 8
totalIngresos``9 F
,``F G
decimal``H O
totalDescuentos``P _
)``_ `
{aa 	
returnbb 
Mathbb 
.bb 
Roundbb 
(bb 
totalIngresosbb +
-bb, -
totalDescuentosbb. =
,bb= >
$numbb? @
,bb@ A
MidpointRoundingbbB R
.bbR S
AwayFromZerobbS _
)bb_ `
;bb` a
}cc 	
publicee 
staticee 
boolee 
ValidarSueldoMinimoee .
(ee. /
decimalee/ 6

sueldoNetoee7 A
,eeA B
decimaleeC J
rmveeK N
)eeN O
{ff 	
returngg 

sueldoNetogg 
>=gg  
rmvgg! $
;gg$ %
}hh 	
}ii 
}kk ©[
kC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\rules\ContratoLaboralRules.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Rules 
{ 
public 

static 
class  
ContratoLaboralRules ,
{ 
public		 
static		 
void		 %
ValidarCamposObligatorios		 4
(		4 5
ContratoLaboral		5 D
contrato		E M
)		M N
{

 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
contrato* 2
.2 3
EmpleadoCodigo3 A
)A B
)B C
throw 
new 
BusinessException +
(+ ,
$str, I
)I J
;J K
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
contrato* 2
.2 3
TipoContratoCodigo3 E
)E F
)F G
throw 
new 
BusinessException +
(+ ,
$str, Q
)Q R
;R S
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
contrato* 2
.2 3
ModalidadCodigo3 B
)B C
)C D
throw 
new 
BusinessException +
(+ ,
$str, R
)R S
;S T
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
contrato* 2
.2 3
JornadaCodigo3 @
)@ A
)A B
throw 
new 
BusinessException +
(+ ,
$str, P
)P Q
;Q R
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
contrato* 2
.2 3
UsuarioCodigo3 @
)@ A
)A B
throw 
new 
BusinessException +
(+ ,
$str, T
)T U
;U V
if 
( 
! 
contrato 
. 
ContratoFechaInicio -
.- .
HasValue. 6
)6 7
throw 
new 
BusinessException +
(+ ,
$str, P
)P Q
;Q R
if 
( 
! 
contrato 
. 
ContratoFechaFin *
.* +
HasValue+ 3
)3 4
throw 
new 
BusinessException +
(+ ,
$str, M
)M N
;N O
} 	
public!! 
static!! 
bool!! "
ContratoProximoAVencer!! 1
(!!1 2
ContratoLaboral!!2 A
contrato!!B J
)!!J K
{"" 	
if## 
(## 
!## 
contrato## 
.## 
ContratoFechaFin## *
.##* +
HasValue##+ 3
)##3 4
return##5 ;
false##< A
;##A B
var$$ 
diasRestantes$$ 
=$$ 
($$  !
contrato$$! )
.$$) *
ContratoFechaFin$$* :
.$$: ;
Value$$; @
-$$A B
DateTime$$C K
.$$K L
Today$$L Q
)$$Q R
.$$R S
	TotalDays$$S \
;$$\ ]
return%% 
diasRestantes%%  
<=%%! #
$num%%$ &
&&%%' )
diasRestantes%%* 7
>=%%8 :
$num%%; <
;%%< =
throw&& 
new&& 
BusinessException&& '
(&&' (
$str&&( k
)&&k l
;&&l m
}'' 	
public)) 
static)) 
void)) $
ValidarContratoDuplicado)) 3
())3 4
bool))4 8!
existeContratoVigente))9 N
)))N O
{** 	
if++ 
(++ !
existeContratoVigente++ %
)++% &
throw,, 
new,, 
BusinessException,, +
(,,+ ,
$str,,, W
),,W X
;,,X Y
}-- 	
public.. 
static.. 
void.. "
ValidarMotivoHistorial.. 1
(..1 2
string..2 8
motivo..9 ?
)..? @
{// 	
if00 
(00 
string00 
.00 
IsNullOrWhiteSpace00 )
(00) *
motivo00* 0
)000 1
)001 2
throw11 
new11 
BusinessException11 +
(11+ ,
$str11, h
)11h i
;11i j
}22 	
public33 
static33 
void33 
ValidarFechaInicio33 -
(33- .
ContratoLaboral33. =
contrato33> F
)33F G
{44 	
if55 
(55 
contrato55 
.55 
ContratoFechaInicio55 ,
.55, -
HasValue55- 5
&&556 8
contrato559 A
.55A B
ContratoFechaInicio55B U
.55U V
Value55V [
.55[ \
Date55\ `
<55a b
DateTime55c k
.55k l
Today55l q
)55q r
throw66 
new66 
BusinessException66 +
(66+ ,
$str66, v
)66v w
;66w x
if77 
(77 
contrato77 
.77 
ContratoFechaFin77 )
.77) *
HasValue77* 2
&&773 5
contrato776 >
.77> ?
ContratoFechaFin77? O
.77O P
Value77P U
<77V W
DateTime77X `
.77` a
Today77a f
)77f g
throw88 
new88 
BusinessException88 +
(88+ ,
$str88, ^
)88^ _
;88_ `
}99 	
public:: 
static:: 
void:: #
ValidarEdicionPorEstado:: 2
(::2 3
string::3 9
estado::: @
)::@ A
{;; 	
if<< 
(<< 
estado<< 
==<< 
null<< 
||<< !
estado<<" (
.<<( )
Trim<<) -
(<<- .
)<<. /
!=<<0 2
$str<<3 6
)<<6 7
throw== 
new== 
BusinessException== +
(==+ ,
$str==, W
)==W X
;==X Y
}>> 	
public@@ 
static@@ 
void@@ 
ValidarReactivacion@@ .
(@@. /
string@@/ 5
?@@5 6
estadoActual@@7 C
,@@C D
string@@E K
?@@K L
nuevoEstado@@M X
)@@X Y
{AA 	
estadoActualBB 
=BB 
estadoActualBB '
?BB' (
.BB( )
TrimBB) -
(BB- .
)BB. /
;BB/ 0
nuevoEstadoCC 
=CC 
nuevoEstadoCC %
?CC% &
.CC& '
TrimCC' +
(CC+ ,
)CC, -
;CC- .
ifDD 
(DD 
estadoActualDD 
==DD 
$strDD  #
&&DD$ &
nuevoEstadoDD' 2
==DD3 5
$strDD6 9
)DD9 :
returnEE 
;EE 
ifFF 
(FF 
estadoActualFF 
==FF 
$strFF  #
&&FF$ &
nuevoEstadoFF' 2
==FF3 5
$strFF6 9
)FF9 :
returnGG 
;GG 
throwHH 
newHH 
BusinessExceptionHH '
(HH' (
$strHH( H
)HHH I
;HHI J
}II 	
publicKK 
staticKK 
voidKK  
ValidarSalarioMinimoKK /
(KK/ 0
decimalKK0 7
salarioKK8 ?
,KK? @
decimalKKA H
salarioMinimoLegalKKI [
)KK[ \
{LL 	
ifMM 
(MM 
salarioMM 
<MM 
salarioMinimoLegalMM ,
)MM, -
throwNN 
newNN 
BusinessExceptionNN +
(NN+ ,
$"NN, .
$strNN. p
{NNp q
salarioMinimoLegal	NNq ƒ
:
NNƒ „
$str
NN„ …
}
NN… †
$str
NN† ˆ
"
NNˆ ‰
)
NN‰ Š
;
NNŠ ‹
}OO 	
publicQQ 
staticQQ 
voidQQ 
ValidarFechasQQ (
(QQ( )
ContratoLaboralQQ) 8
contratoQQ9 A
)QQA B
{RR 	
ifSS 
(SS 
contratoSS 
.SS 
ContratoFechaInicioSS ,
.SS, -
HasValueSS- 5
&&SS6 8
contratoTT 
.TT 
ContratoFechaFinTT )
.TT) *
HasValueTT* 2
&&TT3 5
contratoUU 
.UU 
ContratoFechaFinUU )
<=UU* ,
contratoUU- 5
.UU5 6
ContratoFechaInicioUU6 I
)UUI J
{VV 
throwWW 
newWW 
BusinessExceptionWW +
(WW+ ,
$strWW, d
)WWd e
;WWe f
}XX 
}YY 	
private[[ 
const[[ 
int[[ 
Minimo[[  
=[[! "
$num[[# $
;[[$ %
public]] 
static]] 
void]] &
ValidarPlazoMinimoContrato]] 5
(]]5 6
ContratoLaboral]]6 E
contrato]]F N
)]]N O
{^^ 	
if__ 
(__ 
contrato__ 
.__ 
ContratoFechaInicio__ ,
.__, -
HasValue__- 5
&&__6 8
contrato__9 A
.__A B
ContratoFechaFin__B R
.__R S
HasValue__S [
)__[ \
{`` 
varaa 
fechaInicioaa 
=aa  !
contratoaa" *
.aa* +
ContratoFechaInicioaa+ >
.aa> ?
Valueaa? D
.aaD E
DateaaE I
;aaI J
varbb 
fechaFinbb 
=bb 
contratobb '
.bb' (
ContratoFechaFinbb( 8
.bb8 9
Valuebb9 >
.bb> ?
Datebb? C
;bbC D
varcc 
fechaMinimaFincc "
=cc# $
fechaIniciocc% 0
.cc0 1
	AddMonthscc1 :
(cc: ;
Minimocc; A
)ccA B
;ccB C
ifdd 
(dd 
fechaFindd 
<dd 
fechaMinimaFindd -
)dd- .
{ee 
throwff 
newff 
BusinessExceptionff /
(ff/ 0
$"gg 
$strgg D
{ggD E
MinimoggE K
}ggK L
$strggL T
"ggT U
+ggV W
$"hh 
$strhh >
{hh> ?
fechaMinimaFinhh? M
.hhM N
ToShortDateStringhhN _
(hh_ `
)hh` a
}hha b
$strhhb c
"hhc d
)ii 
;ii 
}jj 
}kk 
}ll 	
publicnn 
staticnn 
voidnn $
ValidarCoherenciaGeneralnn 3
(nn3 4
ContratoLaboralnn4 C
contratonnD L
)nnL M
{oo 	%
ValidarCamposObligatoriospp %
(pp% &
contratopp& .
)pp. /
;pp/ 0
ValidarFechasqq 
(qq 
contratoqq "
)qq" #
;qq# $&
ValidarPlazoMinimoContratorr &
(rr& '
contratorr' /
)rr/ 0
;rr0 1 
ValidarSalarioMinimoss  
(ss  !
contratoss! )
.ss) *
ContratoSalarioss* 9
,ss9 :
$numss; @
)ss@ A
;ssA B
}tt 	
}uu 
}vv õ
mC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\ReadModels\ReporteNominaView.cs
	namespace 	
Nomina
 
. 
Domain 
. 

ReadModels "
{ 
public		 

class		 
ReporteNominaView		 "
{

 
public 
string 
Codigo 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
public 
string 
Empleado 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
public 
DateTime 
fechaIngreso $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
decimal 
SalarioBase "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 
HorasExtras 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
decimal 
MontoHorasExtras '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
decimal 
Bonificacion #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
decimal 
AsignacionFamiliar )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
decimal 
TotalIngresos $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
decimal 
DescPension "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
decimal 
IR5ta 
{ 
get "
;" #
set$ '
;' (
}) *
public 
decimal 
Essalud 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
decimal 
	OtrosDesc  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
decimal 
TotalDescuentos &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
decimal 

SueldoNeto !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
PeriodoInicio #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
null4 8
!8 9
;9 :
public 
string 

PeriodoFin  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
} 
} ¤
fC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\ReadModels\NominaView.cs
	namespace 	
Nomina
 
. 
Domain 
. 

ReadModels "
{ 
public		 

class		 

NominaView		 
{

 
public 
string 
NominaCodigo "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
string 
Nombre 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
public 
decimal 
? 
NominaHorasExtras )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
decimal 
? "
NominaMontoHorasExtras .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
decimal 
? 
ContratoSalario '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
decimal 
? 
NominaBonificacion *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
decimal 
? $
NominaAsignacionFamiliar 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
decimal 
? 
NominaTotalIngresos +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
decimal 
? "
NominaDescuentoPension .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
decimal 
?  
NominaDescuentoIR5ta ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
decimal 
? 
NominaAporteEssalud +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
decimal 
? !
NominaOtrosDescuentos -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
decimal 
? !
NominaTotalDescuentos -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
decimal 
? 
NominaSueldoNeto (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} Ú
hC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\ReadModels\ContratoView.cs
	namespace 	
Nomina
 
. 
Domain 
. 

ReadModels "
{ 
public		 

class		 
ContratoView		 
{

 
public 
string 
? 
ContratoCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
public 
string 
? 
EmpleadoCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
public 
string 
? 
EmpleadoNombre %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
public 
string 
? 
EmpleadoApellido '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
null8 <
!< =
;= >
public 
string 
? 
TipoContratoCodigo )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
null: >
!> ?
;? @
public 
string 
? 
ModalidadCodigo &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
null7 ;
!; <
;< =
public 
string 
? 
JornadaCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
public 
string 
? 
UsuarioCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
public 
string 
? #
TipoContratoDescripcion .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
== >
null? C
!C D
;D E
public 
string 
?  
ModalidadDescripcion +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
=: ;
null< @
!@ A
;A B
public 
string 
? 
JornadaDescripcion )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
DateTime 
ContratoFechaInicio +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
DateTime 
? 
ContratoFechaFin )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
decimal 
ContratoSalario &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
? 
ContratoEstado %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
public 
DateTime !
ContratoFechaRegistro -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
DateTime 
? %
ContratoFechaModificacion 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} ö
tC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Interfaces\IReporteNominaRepository.cs
	namespace 	
Nomina
 
. 
Domain 
. 

Interfaces "
{		 
public

 

	interface

 $
IReporteNominaRepository

 -
{ 
Task 
< 
List 
< 
ReporteNominaView #
># $
>$ %%
ObtenerReporteNominaAsync& ?
(? @
string 
? 
PeriodoCodigo !
=" #
null$ (
,( )
string 
? 
departamentoCodigo &
=' (
null) -
,- .
string 
? 
cargoCodigo 
=  !
null" &
,& '
string 
? 
tipoContratoCodigo &
=' (
null) -
) 	
;	 

} 
} ˆ
mC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Interfaces\INominaRepository.cs
	namespace		 	
Nomina		
 
.		 
Domain		 
.		 

Interfaces		 "
{

 
public 

	interface 
INominaRepository &
{ 
Task 
< 
IEnumerable 
< 

NominaView #
># $
>$ %!
ConsultarNominasAsync& ;
(; <
string< B
codigoPeriodoC P
)P Q
;Q R
Task 
< 
IEnumerable 
< 
PeriodoNomina &
>& '
>' ( 
ObtenerPeriodosAsync) =
(= >
)> ?
;? @
Task 
< 
IEnumerable 
< 
Departamento %
>% &
>& '%
ObtenerDepartamentosAsync( A
(A B
)B C
;C D
Task 
< 
IEnumerable 
< 
ContratoLaboral (
>( )
>) * 
ObtenerContratoAsync+ ?
(? @
)@ A
;A B
Task 
InsertarNominaAsync  
(  !
string! '
nominaCodigo( 4
,4 5
string6 <
periodoCodigo= J
,J K
stringL R
contratoCodigoS a
,a b
intc f
nominaHorasExtrasg x
,x y
decimal	z $
nominaMontoHorasExtras
‚ ˜
,
˜ ™
decimal
š ¡ 
nominaBonificacion
¢ ´
,
´ µ
decimal 
nominaTotalIngresos '
,' (
decimal) 0!
nominaTotalDescuentos1 F
,F G
decimalH O
nominaSueldoNetoP `
,` a
decimalb i%
nominaAsignacionFamiliar	j ‚
,
‚ ƒ
decimal
„ ‹$
nominaDescuentoPension
Œ ¢
,
¢ £
decimal  
nominaDescuentoIR5ta (
,( )
decimal* 1
nominaAporteEssalud2 E
,E F
decimalG N!
nominaOtrosDescuentosO d
,d e
charf j
nominaEstadok w
=x y
$charz }
)} ~
;~ 
Task 
< 
ContratoLaboral 
? 
> +
ObtenerContratoConEmpleadoAsync >
(> ?
string? E
contratoCodigoF T
)T U
;U V
Task 
< 
IEnumerable 
< 
ParametroSistema )
>) *
>* +)
ObtenerParametrosSistemaAsync, I
(I J
)J K
;K L
Task 
< 
string 
? 
> *
ObtenerUltimoCodigoNominaAsync 4
(4 5
)5 6
;6 7
Task 
< 
IEnumerable 
< 
ConceptoNomina '
>' (
>( )4
(ObtenerConceptosPorContratoYPeriodoAsync* R
(R S
stringS Y
contratoCodigoZ h
,h i
stringj p
periodoCodigoq ~
)~ 
;	 €
Task "
ActualizarPeriodoAsync #
(# $
PeriodoNomina$ 1
periodo2 9
)9 :
;: ;
Task 
SaveChangesAsync 
( 
) 
;  
} 
} ¢
vC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Interfaces\IContratoLaboralRepository.cs
	namespace 	
Nomina
 
. 
Domain 
. 

Interfaces "
{ 
public 

	interface &
IContratoLaboralRepository /
{		 
Task

 
InsertarContrato

 
(

 
ContratoLaboral

 -
contrato

. 6
)

6 7
;

7 8
Task 
ModificarContrato 
( 
ContratoLaboral .
contrato/ 7
,7 8
string9 ?
motivo@ F
)F G
;G H
Task 
EliminarContrato 
( 
string $
contratoCodigo% 3
)3 4
;4 5
Task 
SuspenderContrato 
( 
string %
contratoCodigo& 4
,4 5
string6 <
nuevoEstado= H
,H I
stringJ P
motivoQ W
)W X
;X Y
Task 
< 
bool 
> !
ExisteContratoVigente (
(( )
string) /
empleadoCodigo0 >
)> ?
;? @
Task 
< 
bool 
>  
ExisteEmpleadoActivo '
(' (
string( .
empleadoCodigo/ =
)= >
;> ?
Task 
< 
ContratoLaboral 
? 
> 
ObtenerContrato .
(. /
string/ 5
contratoCodigo6 D
)D E
;E F
Task 
RegistrarHistorial 
(  
HistorialContrato  1
	historial2 ;
); <
;< =
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
< 
ContratoView %
>% &
>& '#
ConsultarContratosAsync( ?
(? @
)@ A
;A B
Task 
< 
IEnumerable 
< 
object 
>  
>  !&
ListarEmpleadosSinContrato" <
(< =
)= >
;> ?
} 
} ï
mC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Exceptions\NotFoundException.cs
	namespace 	
Nomina
 
. 
API 
. 

Exceptions 
{ 
public 

class 
NotFoundException "
:# $
	Exception% .
{ 
public 
NotFoundException  
(  !
string! '
message( /
)/ 0
:1 2
base3 7
(7 8
message8 ?
)? @
{A B
}C D
} 
} ï
mC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Exceptions\DatabaseException.cs
	namespace 	
Nomina
 
. 
API 
. 

Exceptions 
{ 
public 

class 
DatabaseException "
:# $
	Exception% .
{ 
public 
DatabaseException  
(  !
string! '
message( /
)/ 0
:1 2
base3 7
(7 8
message8 ?
)? @
{A B
}C D
} 
} ï
mC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Exceptions\BusinessException.cs
	namespace 	
Nomina
 
. 
API 
. 

Exceptions 
{ 
public 

class 
BusinessException "
:# $
	Exception% .
{ 
public 
BusinessException  
(  !
string! '
message( /
)/ 0
:1 2
base3 7
(7 8
message8 ?
)? @
{A B
}C D
} 
} ¾
hC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Exceptions\AppException.cs
	namespace 	
Nomina
 
. 
Domain 
. 

Exceptions "
{ 
public		 

class		 
AppException		 
:		 
	Exception		  )
{

 
public 
AppException 
( 
string "
message# *
,* +
	Exception, 5
inner6 ;
); <
: 
base 
( 
message 
, 
inner !
)! "
{# $
}% &
} 
} ª

aC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\Usuario.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
Usuario		 
{

 
public 
string 
UsuarioCodigo #
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
? 
UsuarioNombre $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
? 
UsuarioCorreo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
? 

UsuarioRol !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
ICollection 
< 
ContratoLaboral *
>* +
?+ ,
ContratosLaborales- ?
{@ A
getB E
;E F
setG J
;J K
}L M
} 
} æ
fC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\TipoContrato.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
TipoContrato		 
{

 
public 
string 
TipoContratoCodigo (
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
? #
TipoContratoDescripcion .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
ICollection 
< 
ContratoLaboral *
>* +
?+ ,
ContratosLaborales- ?
{@ A
getB E
;E F
setG J
;J K
}L M
} 
} ¼
iC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\ResumenEmpleado.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public 

class 
ResumenEmpleado  
{ 
public 
string 
Codigo 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
public 
string 
EmpleadoNombre $
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
;A B
} 
} ¡
gC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\PeriodoNomina.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
PeriodoNomina		 
{

 
public 
string 
? 
PeriodoCodigo $
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
? 
PeriodoTipo "
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
public 
DateTime 
PeriodoInicio %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
DateTime 

PeriodoFin "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
PeriodoEstado $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
public 
int 
PeriodoAnio 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 

PeriodoMes 
{ 
get  #
;# $
set% (
;( )
}* +
public 
DateTime 
PeriodoFechaPago (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
ICollection 
< 
Nominas "
>" #
?# $
Nominas% ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
} 
} Í
jC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\ParametroSistema.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
ParametroSistema		 !
{

 
public 
string 
ParametroCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
public 
string 
? 
ParametroNombre &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
decimal 
? 
ParametroValor &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
int 
? 
ParametroAnio !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} ¬
aC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\Nominas.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
Nominas		 
{

 
public 
string 
NominaCodigo "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
string 
? 
PeriodoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
? 
ContratoCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
int 
? "
NominaMontoHorasExtras *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
=9 :
$num; <
;< =
public 
decimal 
? 
NominaBonificacion *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
=9 :
$num; <
;< =
public 
decimal 
? 
NominaDescuentos (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
$num9 :
;: ;
public 
decimal 
? 
NominaTotalIngresos +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
decimal 
? !
NominaTotalDescuentos -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
decimal 
? 
NominaSueldoNeto (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
DateTime 
? $
NominaFechaProcesamiento 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
=@ A
DateTimeB J
.J K
NowK N
;N O
public 
string 
? 
NominaEstado #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
$str4 7
;7 8
public 
PeriodoNomina 
? 
Periodo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
ContratoLaboral 
? 
Contrato  (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
ICollection 
< 
DescuentoAdicional -
>- .
?. /!
DescuentosAdicionales0 E
{F G
getH K
;K L
setM P
;P Q
}R S
} 
} â
gC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\ModalidadPago.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
ModalidadPago		 
{

 
public 
string 
ModalidadCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
public 
string 
?  
ModalidadDescripcion +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
ICollection 
< 
ContratoLaboral *
>* +
?+ ,
ContratosLaborales- ?
{@ A
getB E
;E F
setG J
;J K
}L M
} 
} 

jC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\HistorialDetalle.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public 

class 
HistorialDetalle !
{ 
public 
string 
? 
ContratoCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
? 
Detalle 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
?		 
Motivo		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
[

 	

JsonIgnore

	 
]

 
public 
DateTime 
HistorialFecha &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
HistorialFechaF %
=>& (
HistorialFecha) 7
.7 8
ToString8 @
(@ A
$strA V
)V W
;W X
} 
} ¤
kC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\HistorialContrato.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public 

class 
HistorialContrato "
{ 
public 
string 
HistorialCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
string6 <
.< =
Empty= B
;B C
public 
string 
ContratoCodigo $
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
string		 
EventoCodigo		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
=		1 2
string		3 9
.		9 :
Empty		: ?
;		? @
public

 
string

 
HistorialMotivo
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
string 
HistorialDetalle &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
string7 =
.= >
Empty> C
;C D
public 
DateTime 
HistorialFecha &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
DateTime7 ?
.? @
Now@ C
;C D
} 
} à
hC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\JornadaLaboral.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
JornadaLaboral		 
{

 
public 
string 
JornadaCodigo #
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
? 
JornadaDescripcion )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
ICollection 
< 
ContratoLaboral *
>* +
?+ ,
ContratosLaborales- ?
{@ A
getB E
;E F
setG J
;J K
}L M
} 
} ˜
hC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\EventoContrato.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
EventoContrato		 
{

 
public 
string 
EventoCodigo "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
string 
? 
EventoNombre #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
? 
EventoDescripcion (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ú
bC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\Empleado.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
Empleado		 
{

 
public 
string 
EmpleadoCodigo $
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
? 
EmpleadoNombre %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
? 
EmpleadoApellido '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
? 
EmpleadoDNI "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
DateTime 
? 
FechaIngreso %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
DepartamentoCodigo (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
public 
string 
? 
CargoCodigo "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
EmpleadoEstado $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
public 
bool 
? 
EmpleadoTieneHijos '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
? 
EmpleadoTipoPension *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string 
? 
EmpleadoAFP "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
Departamento 
? 
Departamento )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
Cargo 
? 
Cargo 
{ 
get !
;! "
set# &
;& '
}( )
public 
ICollection 
< 
ContratoLaboral *
>* +
ContratosLaborales, >
{? @
getA D
;D E
setF I
;I J
}K L
=M N
nullO S
!S T
;T U
} 
} í
lC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\DescuentoAdicional.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
DescuentoAdicional		 #
{

 
public 
string 
DescuentoCodigo %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
public 
string 
? 
NominaCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
? 
DescuentoTipo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
decimal 
? 
DescuentoMonto &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
? 
DescuentoMotivo &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
? "
DescuentoAutorizadoPor -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
DateTime 
? 
DescuentoFecha '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
DateTime8 @
.@ A
NowA D
;D E
public 
Nominas 
? 
Nomina 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} 
fC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\Departamento.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
Departamento		 
{

 
public 
string 
DepartamentoCodigo (
{) *
set+ .
;. /
get0 3
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
set+ .
;. /
get0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
public 
ICollection 
< 
Empleado #
># $
?$ %
	Empleados& /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
} 
} ¯
iC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\ContratoResumen.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public 

class 
ContratoResumen  
{ 
public 
string 
? 
Codigo 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
Descripcion "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ”
iC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\ContratoLaboral.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
ContratoLaboral		  
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
string 
EmpleadoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
public 
string 
? 
TipoContratoCodigo )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
string 
? 
ModalidadCodigo &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
? 
JornadaCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
? 
UsuarioCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime 
? 
ContratoFechaInicio ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
DateTime 
? 
ContratoFechaFin )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
decimal 
ContratoSalario &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
ContratoEstado $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
$str5 8
;8 9
public 
DateTime 
? !
ContratoFechaRegistro .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
== >
DateTime? G
.G H
NowH K
;K L
public 
DateTime 
? %
ContratoFechaModificacion 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
Empleado 
? 
Empleado !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
TipoContrato 
? 
TipoContrato )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
ModalidadPago 
? 
	Modalidad '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
JornadaLaboral 
? 
Jornada &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
Usuario 
? 
Usuario 
{  !
get" %
;% &
set' *
;* +
}, -
public 
ICollection 
< 
Nominas "
>" #
Nominas$ +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
=: ;
null< @
!@ A
;A B
} 
} Ä
hC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\ConceptoNomina.cs
	namespace		 	
Nomina		
 
.		 
Domain		 
.		 
Entities		  
{

 
[ 
Table 

(
 
$str 
) 
] 
public 

class 
ConceptoNomina 
{ 
[ 	
Key	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
ConceptoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
string5 ;
.; <
Empty< A
;A B
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
ContratoCodigo $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
string5 ;
.; <
Empty< A
;A B
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
PeriodoCodigo #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
string4 :
.: ;
Empty; @
;@ A
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
TipoConcepto "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
[ 	
Column	 
( 
TypeName 
= 
$str *
)* +
]+ ,
public 
decimal 
? 
Monto 
{ 
get  #
;# $
set% (
;( )
}* +
public!! 
int!! 
?!! 
HorasExtras!! 
{!!  !
get!!" %
;!!% &
set!!' *
;!!* +
}!!, -
[## 	
StringLength##	 
(## 
$num## 
)## 
]## 
public$$ 
string$$ 
?$$ 
Descripcion$$ "
{$$# $
get$$% (
;$$( )
set$$* -
;$$- .
}$$/ 0
public&& 
DateTime&& 
FechaRegistro&& %
{&&& '
get&&( +
;&&+ ,
set&&- 0
;&&0 1
}&&2 3
=&&4 5
DateTime&&6 >
.&&> ?
Now&&? B
;&&B C
public(( 
ContratoLaboral(( 
?(( 
Contrato((  (
{(() *
get((+ .
;((. /
set((0 3
;((3 4
}((5 6
public)) 
PeriodoNomina)) 
?)) 
Periodo)) %
{))& '
get))( +
;))+ ,
set))- 0
;))0 1
}))2 3
}** 
}++ µ
_C:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Entities\Cargo.cs
	namespace 	
Nomina
 
. 
Domain 
. 
Entities  
{ 
public		 

class		 
Cargo		 
{

 
public 
string 
CargoCodigo !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
public 
string 
? 
CargoNombre "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
ICollection 
< 
Empleado #
># $
?$ %
	Empleados& /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
} 
} €
oC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Domain\Constants\ValidacionesContrato.cs
	namespace 	
Nomina
 
. 
Domain 
. 
	Constants !
{ 
public 

static 
class  
ValidacionesContrato ,
{ 
public 
const 
decimal 
SALARIO_MINIMO +
=, -
$num. 6
;6 7
} 
} 