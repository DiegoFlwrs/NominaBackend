§
}C:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Infrastructure\Repositories\ReporteNominaRepository.cs
	namespace 	
Nomina
 
. 
Infrastructure 
.  
Repositories  ,
{ 
public 

class #
ReporteNominaRepository (
:) *$
IReporteNominaRepository+ C
{ 
private 
readonly 
string 
_connectionString  1
;1 2
public #
ReporteNominaRepository &
(& '
string' -
connectionString. >
)> ?
{ 	
this 
. 
_connectionString "
=# $
connectionString% 5
;5 6
} 	
public 
async 
Task 
< 
List 
< 
ReporteNominaView 0
>0 1
>1 2%
ObtenerReporteNominaAsync3 L
(L M
string 
? 
PeriodoCodigo !
=" #
null$ (
,( )
string 
? 
departamentoCodigo &
=' (
null) -
,- .
string 
? 
cargoCodigo 
=  !
null" &
,& '
string 
? 
tipoContratoCodigo &
=' (
null) -
) 	
{ 	
const 
string 
spName 
=  !
$str" K
;K L
var 

parameters 
= 
new  
DynamicParameters! 2
(2 3
)3 4
;4 5

parameters!! 
.!! 
Add!! 
(!! 
$str!! +
,!!+ ,
PeriodoCodigo!!- :
)!!: ;
;!!; <

parameters"" 
."" 
Add"" 
("" 
$str"" 0
,""0 1
departamentoCodigo""2 D
)""D E
;""E F

parameters## 
.## 
Add## 
(## 
$str## )
,##) *
cargoCodigo##+ 6
)##6 7
;##7 8

parameters$$ 
.$$ 
Add$$ 
($$ 
$str$$ 0
,$$0 1
tipoContratoCodigo$$2 D
)$$D E
;$$E F
using&& 
(&& 
var&& 

connection&& !
=&&" #
new&&$ '
SqlConnection&&( 5
(&&5 6
_connectionString&&6 G
)&&G H
)&&H I
{'' 
var(( 
reporteData(( 
=((  !
await((" '

connection((( 2
.((2 3

QueryAsync((3 =
<((= >
ReporteNominaView((> O
>((O P
(((P Q
spName)) 
,)) 

parameters** 
,** 
commandType++ 
:++  
CommandType++! ,
.++, -
StoredProcedure++- <
),, 
;,, 
return.. 
reporteData.. "
..." #
ToList..# )
(..) *
)..* +
;..+ ,
}// 
}00 	
}11 
}22  ë
vC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Infrastructure\Repositories\NominaRepository.cs
	namespace 	
Nomina
 
. 
Infrastructure 
.  
Repositories  ,
{ 
public 

class 
NominaRepository !
:" #
INominaRepository$ 5
{ 
private 
readonly 
string 
_connectionString  1
;1 2
private 
readonly 
AppDbContext %
_context& .
;. /
public 
NominaRepository 
(  
AppDbContext  ,
context- 4
,4 5
string6 <
connectionString= M
)M N
{ 	
_connectionString 
= 
connectionString  0
;0 1
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
IEnumerable %
<% &

NominaView& 0
>0 1
>1 2!
ConsultarNominasAsync3 H
(H I
stringI O
codigoPeriodoP ]
)] ^
{ 	
try 
{ 
using 
( 
SqlConnection $
con% (
=) *
new+ .
SqlConnection/ <
(< =
_connectionString= N
)N O
)O P
{ 
var 

parameters "
=# $
new% (
{   
CodigoPeriodo!! %
=!!& '
codigoPeriodo!!( 5
}"" 
;"" 
var$$ 
nominas$$ 
=$$  !
await$$" '
con$$( +
.$$+ ,

QueryAsync$$, 6
<$$6 7

NominaView$$7 A
>$$A B
($$B C
$str%% *
,%%* +

parameters&& "
,&&" #
commandType'' #
:''# $
CommandType''% 0
.''0 1
StoredProcedure''1 @
)(( 
;(( 
return** 
nominas** "
;**" #
}++ 
},, 
catch-- 
(-- 
SqlException-- 
ex--  "
)--" #
{.. 
throw// 
new// 
DatabaseException// +
(//+ ,
$"//, .
$str//. I
{//I J
ex//J L
.//L M
Message//M T
}//T U
"//U V
)//V W
;//W X
}00 
catch11 
(11 
	Exception11 
ex11 
)11  
{22 
throw33 
new33 
AppException33 &
(33& '
$str33' 4
+335 6
ex337 9
.339 :
Message33: A
,33A B
ex33C E
)33E F
;33F G
}44 
}55 	
public88 
async88 
Task88 
<88 
IEnumerable88 %
<88% &
PeriodoNomina88& 3
>883 4
>884 5 
ObtenerPeriodosAsync886 J
(88J K
)88K L
{99 	
try:: 
{;; 
return<< 
await<< 
_context<< %
.<<% &
PeriodosNomina<<& 4
.== 
OrderByDescending== "
(==" #
p==# $
=>==% '
p==( )
.==) *
PeriodoAnio==* 5
)==5 6
.>> 
ThenByDescending>> !
(>>! "
p>>" #
=>>>$ &
p>>' (
.>>( )

PeriodoMes>>) 3
)>>3 4
.?? 
ToListAsync?? 
(?? 
)?? 
;?? 
}@@ 
catchAA 
(AA 
	ExceptionAA 
exAA 
)AA  
{BB 
throwCC 
newCC 
AppExceptionCC &
(CC& '
$strCC' 4
+CC5 6
exCC7 9
.CC9 :
MessageCC: A
,CCA B
exCCC E
)CCE F
;CCF G
}DD 
}EE 	
publicGG 
asyncGG 
TaskGG 
<GG 
IEnumerableGG %
<GG% &
DepartamentoGG& 2
>GG2 3
>GG3 4%
ObtenerDepartamentosAsyncGG5 N
(GGN O
)GGO P
{HH 	
tryII 
{JJ 
returnKK 
awaitKK 
_contextKK %
.KK% &
DepartamentosKK& 3
.KK3 4
ToListAsyncKK4 ?
(KK? @
)KK@ A
;KKA B
}LL 
catchMM 
(MM 
	ExceptionMM 
exMM 
)MM  
{NN 
throwOO 
newOO 
AppExceptionOO &
(OO& '
$strOO' 4
+OO5 6
exOO7 9
.OO9 :
MessageOO: A
,OOA B
exOOC E
)OOE F
;OOF G
}PP 
}QQ 	
publicSS 
asyncSS 
TaskSS 
<SS 
IEnumerableSS %
<SS% &
ContratoLaboralSS& 5
>SS5 6
>SS6 7 
ObtenerContratoAsyncSS8 L
(SSL M
)SSM N
{TT 	
tryUU 
{VV 
returnWW 
awaitWW 
_contextWW %
.WW% &
ContratosLaboralesWW& 8
.XX 
IncludeXX 
(XX 
cXX 
=>XX !
cXX" #
.XX# $
EmpleadoXX$ ,
)XX, -
.XX- .
ToListAsyncYY 
(YY  
)YY  !
;YY! "
}ZZ 
catch[[ 
([[ 
	Exception[[ 
ex[[ 
)[[  
{\\ 
throw]] 
new]] 
AppException]] &
(]]& '
$str]]' 4
+]]5 6
ex]]7 9
.]]9 :
Message]]: A
,]]A B
ex]]C E
)]]E F
;]]F G
}^^ 
}__ 	
publicbb 
asyncbb 
Taskbb 
InsertarNominaAsyncbb -
(bb- .
stringbb/ 5
nominaCodigobb6 B
,bbB C
stringbbD J
periodoCodigobbK X
,bbX Y
stringbbZ `
contratoCodigobba o
,bbo p
intbbq t
nominaHorasExtras	bbu Ü
,
bbÜ á
decimal
bbà è$
nominaMontoHorasExtras
bbê ¶
,
bb¶ ß
decimal
bb® Ø 
nominaBonificacion
bb∞ ¬
,
bb¬ √
decimalcc 
nominaTotalIngresoscc '
,cc' (
decimalcc) 0!
nominaTotalDescuentoscc1 F
,ccF G
decimalccH O
nominaSueldoNetoccP `
,cc` a
decimalccb i%
nominaAsignacionFamiliar	ccj Ç
,
ccÇ É
decimal
ccÑ ã$
nominaDescuentoPension
ccå ¢
,
cc¢ £
decimaldd  
nominaDescuentoIR5tadd (
,dd( )
decimaldd* 1
nominaAporteEssaluddd2 E
,ddE F
decimalddG N!
nominaOtrosDescuentosddO d
,ddd e
charddf j
nominaEstadoddk w
=ddx y
$charddz }
)dd} ~
{ee 	
tryff 
{gg 
usinghh 
(hh 
SqlConnectionhh $
conhh% (
=hh) *
newhh+ .
SqlConnectionhh/ <
(hh< =
_connectionStringhh= N
)hhN O
)hhO P
{ii 
varjj 

parametersjj "
=jj# $
newjj% (
{kk 
NominaCodigoll $
=ll% &
nominaCodigoll' 3
,ll3 4
PeriodoCodigomm %
=mm& '
periodoCodigomm( 5
,mm5 6
ContratoCodigonn &
=nn' (
contratoCodigonn) 7
,nn7 8
NominaHorasExtrasoo )
=oo* +
nominaHorasExtrasoo, =
,oo= >"
NominaMontoHorasExtraspp .
=pp/ 0"
nominaMontoHorasExtraspp1 G
,ppG H
NominaBonificacionqq *
=qq+ ,
nominaBonificacionqq- ?
,qq? @$
NominaAsignacionFamiliarrr 0
=rr1 2$
nominaAsignacionFamiliarrr3 K
,rrK L
NominaTotalIngresosss +
=ss, -
nominaTotalIngresosss. A
,ssA B"
NominaDescuentoPensiontt .
=tt/ 0"
nominaDescuentoPensiontt1 G
,ttG H 
NominaDescuentoIR5tauu ,
=uu- . 
nominaDescuentoIR5tauu/ C
,uuC D
NominaAporteEssaludvv +
=vv, -
nominaAporteEssaludvv. A
,vvA B!
NominaOtrosDescuentosww -
=ww. /!
nominaOtrosDescuentosww0 E
,wwE F!
NominaTotalDescuentosxx -
=xx. /!
nominaTotalDescuentosxx0 E
,xxE F
NominaSueldoNetoyy (
=yy) *
nominaSueldoNetoyy+ ;
,yy; <
NominaEstadozz $
=zz% &
nominaEstadozz' 3
}{{ 
;{{ 
await}} 
con}} 
.}} 
ExecuteAsync}} *
(}}* +
$str~~ (
,~~( )

parameters "
," #
commandType
ÄÄ #
:
ÄÄ# $
System
ÄÄ% +
.
ÄÄ+ ,
Data
ÄÄ, 0
.
ÄÄ0 1
CommandType
ÄÄ1 <
.
ÄÄ< =
StoredProcedure
ÄÄ= L
)
ÅÅ 
;
ÅÅ 
}
ÇÇ 
}
ÉÉ 
catch
ÑÑ 
(
ÑÑ 
SqlException
ÑÑ 
ex
ÑÑ  "
)
ÑÑ" #
{
ÖÖ 
throw
ÜÜ 
new
ÜÜ 
DatabaseException
ÜÜ +
(
ÜÜ+ ,
$"
ÜÜ, .
$str
ÜÜ. I
{
ÜÜI J
ex
ÜÜJ L
.
ÜÜL M
Message
ÜÜM T
}
ÜÜT U
"
ÜÜU V
)
ÜÜV W
;
ÜÜW X
}
áá 
catch
àà 
(
àà 
	Exception
àà 
ex
àà 
)
àà  
{
ââ 
throw
ää 
new
ää 
AppException
ää &
(
ää& '
$str
ää' 4
+
ää5 6
ex
ää7 9
.
ää9 :
Message
ää: A
,
ääA B
ex
ääC E
)
ääE F
;
ääF G
}
ãã 
}
åå 	
public
èè 
async
èè 
Task
èè 
<
èè 
ContratoLaboral
èè )
?
èè) *
>
èè* +-
ObtenerContratoConEmpleadoAsync
èè, K
(
èèK L
string
èèL R
contratoCodigo
èèS a
)
èèa b
{
êê 	
try
ëë 
{
íí 
return
ìì 
await
ìì 
_context
ìì %
.
ìì% & 
ContratosLaborales
ìì& 8
.
îî 
Include
îî 
(
îî 
c
îî 
=>
îî !
c
îî" #
.
îî# $
Empleado
îî$ ,
)
îî, -
.
ïï !
FirstOrDefaultAsync
ïï (
(
ïï( )
c
ïï) *
=>
ïï+ -
c
ïï. /
.
ïï/ 0
ContratoCodigo
ïï0 >
==
ïï? A
contratoCodigo
ïïB P
&&
ïïQ S
c
ïïT U
.
ïïU V
ContratoEstado
ïïV d
==
ïïe g
$str
ïïh k
)
ïïk l
;
ïïl m
}
ññ 
catch
óó 
(
óó 
	Exception
óó 
ex
óó 
)
óó  
{
òò 
throw
ôô 
new
ôô 
AppException
ôô &
(
ôô& '
$str
ôô' 4
+
ôô5 6
ex
ôô7 9
.
ôô9 :
Message
ôô: A
,
ôôA B
ex
ôôC E
)
ôôE F
;
ôôF G
}
öö 
}
õõ 	
public
ùù 
async
ùù 
Task
ùù 
<
ùù 
ContratoLaboral
ùù )
?
ùù) *
>
ùù* +#
ObtenerContratosAsync
ùù, A
(
ùùA B
)
ùùB C
{
ûû 	
try
üü 
{
†† 
var
°° 
hoy
°° 
=
°° 
DateTime
°° "
.
°°" #
Now
°°# &
.
°°& '
Date
°°' +
;
°°+ ,
return
££ 
await
££ 
_context
££ %
.
££% & 
ContratosLaborales
££& 8
.
§§ 
Include
§§ 
(
§§ 
c
§§ 
=>
§§ !
c
§§" #
.
§§# $
Empleado
§§$ ,
)
§§, -
.
•• !
FirstOrDefaultAsync
•• (
(
••( )
c
••) *
=>
••+ -
c
••. /
.
••/ 0
ContratoEstado
••0 >
==
••? A
$str
••B E
&&
••F H
c
¶¶ 
.
¶¶ !
ContratoFechaInicio
¶¶ -
<=
¶¶. 0
hoy
¶¶1 4
&&
¶¶5 7
c
ßß 
.
ßß 
ContratoFechaFin
ßß *
>=
ßß+ -
hoy
ßß. 1
)
®® 
;
®® 
}
©© 
catch
™™ 
(
™™ 
	Exception
™™ 
ex
™™ 
)
™™  
{
´´ 
throw
¨¨ 
new
¨¨ 
AppException
¨¨ &
(
¨¨& '
$str
¨¨' 4
+
¨¨5 6
ex
¨¨7 9
.
¨¨9 :
Message
¨¨: A
,
¨¨A B
ex
¨¨C E
)
¨¨E F
;
¨¨F G
}
≠≠ 
}
ÆÆ 	
public
∞∞ 
async
∞∞ 
Task
∞∞ 
<
∞∞ 
IEnumerable
∞∞ %
<
∞∞% &
ParametroSistema
∞∞& 6
>
∞∞6 7
>
∞∞7 8+
ObtenerParametrosSistemaAsync
∞∞9 V
(
∞∞V W
)
∞∞W X
{
±± 	
try
≤≤ 
{
≥≥ 
return
¥¥ 
await
¥¥ 
_context
¥¥ %
.
¥¥% &
ParametrosSistema
¥¥& 7
.
µµ 
ToListAsync
µµ  
(
µµ  !
)
µµ! "
;
µµ" #
}
∂∂ 
catch
∑∑ 
(
∑∑ 
	Exception
∑∑ 
ex
∑∑ 
)
∑∑  
{
∏∏ 
throw
ππ 
new
ππ 
AppException
ππ &
(
ππ& '
$str
ππ' 4
+
ππ5 6
ex
ππ7 9
.
ππ9 :
Message
ππ: A
,
ππA B
ex
ππC E
)
ππE F
;
ππF G
}
∫∫ 
}
ªª 	
public
ΩΩ 
async
ΩΩ 
Task
ΩΩ 
<
ΩΩ 
string
ΩΩ  
?
ΩΩ  !
>
ΩΩ! ",
ObtenerUltimoCodigoNominaAsync
ΩΩ# A
(
ΩΩA B
)
ΩΩB C
{
ææ 	
try
øø 
{
¿¿ 
var
¡¡ 
ultimo
¡¡ 
=
¡¡ 
await
¡¡ "
_context
¡¡# +
.
¡¡+ ,
Nominas
¡¡, 3
.
¬¬ 
OrderByDescending
¬¬ &
(
¬¬& '
n
¬¬' (
=>
¬¬) +
n
¬¬, -
.
¬¬- .
NominaCodigo
¬¬. :
)
¬¬: ;
.
√√ 
Select
√√ 
(
√√ 
n
√√ 
=>
√√  
n
√√! "
.
√√" #
NominaCodigo
√√# /
)
√√/ 0
.
ƒƒ !
FirstOrDefaultAsync
ƒƒ (
(
ƒƒ( )
)
ƒƒ) *
;
ƒƒ* +
return
∆∆ 
ultimo
∆∆ 
;
∆∆ 
}
«« 
catch
»» 
(
»» 
	Exception
»» 
ex
»» 
)
»»  
{
…… 
throw
   
new
   
AppException
   &
(
  & '
$str
  ' 4
+
  5 6
ex
  7 9
.
  9 :
Message
  : A
,
  A B
ex
  C E
)
  E F
;
  F G
}
ÀÀ 
}
ÃÃ 	
public
ŒŒ 
async
ŒŒ 
Task
ŒŒ 
<
ŒŒ 
IEnumerable
ŒŒ %
<
ŒŒ% &
ConceptoNomina
ŒŒ& 4
>
ŒŒ4 5
>
ŒŒ5 66
(ObtenerConceptosPorContratoYPeriodoAsync
ŒŒ7 _
(
ŒŒ_ `
string
ŒŒ` f
contratoCodigo
ŒŒg u
,
ŒŒu v
string
ŒŒw }
periodoCodigoŒŒ~ ã
)ŒŒã å
{
œœ 	
try
–– 
{
—— 
return
““ 
await
““ 
_context
““ %
.
““% &
ConceptosNomina
““& 5
.
”” 
Where
”” 
(
”” 
c
”” 
=>
”” 
c
””  !
.
””! "
ContratoCodigo
””" 0
==
””1 3
contratoCodigo
””4 B
&&
””C E
c
””F G
.
””G H
PeriodoCodigo
””H U
==
””V X
periodoCodigo
””Y f
)
””f g
.
‘‘ 
ToListAsync
‘‘  
(
‘‘  !
)
‘‘! "
;
‘‘" #
}
’’ 
catch
÷÷ 
(
÷÷ 
	Exception
÷÷ 
ex
÷÷ 
)
÷÷  
{
◊◊ 
throw
ÿÿ 
new
ÿÿ 
AppException
ÿÿ &
(
ÿÿ& '
$str
ÿÿ' 4
+
ÿÿ5 6
ex
ÿÿ7 9
.
ÿÿ9 :
Message
ÿÿ: A
,
ÿÿA B
ex
ÿÿC E
)
ÿÿE F
;
ÿÿF G
}
ŸŸ 
}
⁄⁄ 	
public
‹‹ 
async
‹‹ 
Task
‹‹ $
ActualizarPeriodoAsync
‹‹ 0
(
‹‹0 1
PeriodoNomina
‹‹1 >
periodo
‹‹? F
)
‹‹F G
{
›› 	
try
ﬁﬁ 
{
ﬂﬂ 
_context
‡‡ 
.
‡‡ 
PeriodosNomina
‡‡ '
.
‡‡' (
Update
‡‡( .
(
‡‡. /
periodo
‡‡/ 6
)
‡‡6 7
;
‡‡7 8
await
·· 
_context
·· 
.
·· 
SaveChangesAsync
·· /
(
··/ 0
)
··0 1
;
··1 2
}
‚‚ 
catch
„„ 
(
„„ 
	Exception
„„ 
ex
„„ 
)
„„  
{
‰‰ 
throw
ÂÂ 
new
ÂÂ 
AppException
ÂÂ &
(
ÂÂ& '
$str
ÂÂ' 4
+
ÂÂ5 6
ex
ÂÂ7 9
.
ÂÂ9 :
Message
ÂÂ: A
,
ÂÂA B
ex
ÂÂC E
)
ÂÂE F
;
ÂÂF G
}
ÊÊ 
}
ÁÁ 	
public
ÈÈ 
async
ÈÈ 
Task
ÈÈ 
SaveChangesAsync
ÈÈ *
(
ÈÈ* +
)
ÈÈ+ ,
{
ÍÍ 	
try
ÎÎ 
{
ÏÏ 
await
ÌÌ 
_context
ÌÌ 
.
ÌÌ 
SaveChangesAsync
ÌÌ /
(
ÌÌ/ 0
)
ÌÌ0 1
;
ÌÌ1 2
}
ÓÓ 
catch
ÔÔ 
(
ÔÔ 
	Exception
ÔÔ 
ex
ÔÔ 
)
ÔÔ  
{
 
throw
ÒÒ 
new
ÒÒ 
AppException
ÒÒ &
(
ÒÒ& '
$str
ÒÒ' 4
+
ÒÒ5 6
ex
ÒÒ7 9
.
ÒÒ9 :
Message
ÒÒ: A
,
ÒÒA B
ex
ÒÒC E
)
ÒÒE F
;
ÒÒF G
}
ÚÚ 
}
ÛÛ 	
}
ıı 
}ˆˆ ﬁ¶
C:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Infrastructure\Repositories\ContratoLaboralRepository.cs
	namespace 	
Nomina
 
. 
Infrastructure 
.  
Repositories  ,
{ 
public 

class %
ContratoLaboralRepository *
:+ ,&
IContratoLaboralRepository- G
{ 
private 
readonly 
AppDbContext %
_context& .
;. /
private 
readonly 
string 
_connectionString  1
;1 2
public %
ContratoLaboralRepository (
(( )
AppDbContext) 5
context6 =
,= >
string? E
connectionStringF V
)V W
{ 	
_context 
= 
context 
; 
_connectionString 
= 
connectionString  0
;0 1
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
ContratoView& 2
>2 3
>3 4#
ConsultarContratosAsync5 L
(L M
)M N
{ 	
try 
{ 
using 
var 
con 
= 
new  #
SqlConnection$ 1
(1 2
_connectionString2 C
)C D
;D E
var   
	contratos   
=   
await    %
con  & )
.  ) *

QueryAsync  * 4
<  4 5
ContratoView  5 A
>  A B
(  B C
$str!! 1
,!!1 2
commandType"" 
:""  
System""! '
.""' (
Data""( ,
."", -
CommandType""- 8
.""8 9
StoredProcedure""9 H
)## 
;## 
return%% 
	contratos%%  
;%%  !
}&& 
catch'' 
('' 
SqlException'' 
ex''  "
)''" #
{(( 
throw)) 
new)) 
DatabaseException)) +
())+ ,
$")), .
$str)). I
{))I J
ex))J L
.))L M
Message))M T
}))T U
"))U V
)))V W
;))W X
}** 
catch++ 
(++ 
	Exception++ 
ex++ 
)++  
{,, 
throw-- 
new-- 
AppException-- &
(--& '
$str--' 4
+--5 6
ex--7 9
.--9 :
Message--: A
,--A B
ex--C E
)--E F
;--F G
}.. 
}// 	
public00 
async00 
Task00 
InsertarContrato00 *
(00* +
ContratoLaboral00+ :
contrato00; C
)00C D
{11 	
try22 
{33 
contrato44 
.44 
ContratoCodigo44 '
=44( )
await44* /!
GenerarCodigoContrato440 E
(44E F
)44F G
;44G H
var55 

parametros55 
=55  
new55! $
[55$ %
]55% &
{66 
new77 
SqlParameter77 $
(77$ %
$str77% 6
,776 7
contrato778 @
.77@ A
ContratoCodigo77A O
)77O P
,77P Q
new88 
SqlParameter88 $
(88$ %
$str88% 6
,886 7
contrato888 @
.88@ A
EmpleadoCodigo88A O
)88O P
,88P Q
new99 
SqlParameter99 $
(99$ %
$str99% :
,99: ;
contrato99< D
.99D E
TipoContratoCodigo99E W
??99X Z
(99[ \
object99\ b
)99b c
DBNull99c i
.99i j
Value99j o
)99o p
,99p q
new:: 
SqlParameter:: $
(::$ %
$str::% 7
,::7 8
contrato::9 A
.::A B
ModalidadCodigo::B Q
??::R T
(::U V
object::V \
)::\ ]
DBNull::] c
.::c d
Value::d i
)::i j
,::j k
new;; 
SqlParameter;; $
(;;$ %
$str;;% 5
,;;5 6
contrato;;7 ?
.;;? @
JornadaCodigo;;@ M
??;;N P
(;;Q R
object;;R X
);;X Y
DBNull;;Y _
.;;_ `
Value;;` e
);;e f
,;;f g
new<< 
SqlParameter<< $
(<<$ %
$str<<% 5
,<<5 6
contrato<<7 ?
.<<? @
UsuarioCodigo<<@ M
??<<N P
(<<Q R
object<<R X
)<<X Y
DBNull<<Y _
.<<_ `
Value<<` e
)<<e f
,<<f g
new== 
SqlParameter== $
(==$ %
$str==% ;
,==; <
contrato=== E
.==E F
ContratoFechaInicio==F Y
??==Z \
DateTime==] e
.==e f
Now==f i
)==i j
,==j k
new>> 
SqlParameter>> $
(>>$ %
$str>>% 8
,>>8 9
contrato>>: B
.>>B C
ContratoFechaFin>>C S
??>>T V
(>>W X
object>>X ^
)>>^ _
DBNull>>_ e
.>>e f
Value>>f k
)>>k l
,>>l m
new?? 
SqlParameter?? $
(??$ %
$str??% 7
,??7 8
contrato??9 A
.??A B
ContratoSalario??B Q
)??Q R
}@@ 
;@@ 
awaitBB 
_contextBB 
.BB 
DatabaseBB '
.BB' (
ExecuteSqlRawAsyncBB( :
(BB: ;
$str	CC Ÿ
,
CCŸ ⁄

parametrosDD 
)EE 
;EE 
}FF 
catchGG 
(GG 
SqlExceptionGG 
exGG  "
)GG" #
{HH 
throwII 
newII 
DatabaseExceptionII +
(II+ ,
$"II, .
$strII. U
{IIU V
exIIV X
.IIX Y
MessageIIY `
}II` a
"IIa b
)IIb c
;IIc d
}JJ 
catchKK 
(KK 
	ExceptionKK 
exKK 
)KK  
{LL 
throwMM 
newMM 
AppExceptionMM &
(MM& '
$strMM' 4
+MM5 6
exMM7 9
.MM9 :
MessageMM: A
,MMA B
exMMC E
)MME F
;MMF G
}NN 
}OO 	
publicPP 
asyncPP 
TaskPP 
ModificarContratoPP +
(PP+ ,
ContratoLaboralPP, ;
contratoPP< D
,PPD E
stringPPF L
motivoPPM S
)PPS T
{QQ 	
tryRR 
{SS 
varTT 

parametrosTT 
=TT  
newTT! $
[TT$ %
]TT% &
{UU 
newVV 
SqlParameterVV $
(VV$ %
$strVV% 6
,VV6 7
contratoVV8 @
.VV@ A
ContratoCodigoVVA O
)VVO P
,VVP Q
newWW 
SqlParameterWW $
(WW$ %
$strWW% :
,WW: ;
contratoWW< D
.WWD E
TipoContratoCodigoWWE W
??WWX Z
(WW[ \
objectWW\ b
)WWb c
DBNullWWc i
.WWi j
ValueWWj o
)WWo p
,WWp q
newXX 
SqlParameterXX $
(XX$ %
$strXX% 7
,XX7 8
contratoXX9 A
.XXA B
ModalidadCodigoXXB Q
??XXR T
(XXU V
objectXXV \
)XX\ ]
DBNullXX] c
.XXc d
ValueXXd i
)XXi j
,XXj k
newYY 
SqlParameterYY $
(YY$ %
$strYY% 5
,YY5 6
contratoYY7 ?
.YY? @
JornadaCodigoYY@ M
??YYN P
(YYQ R
objectYYR X
)YYX Y
DBNullYYY _
.YY_ `
ValueYY` e
)YYe f
,YYf g
newZZ 
SqlParameterZZ $
(ZZ$ %
$strZZ% 5
,ZZ5 6
contratoZZ7 ?
.ZZ? @
UsuarioCodigoZZ@ M
??ZZN P
(ZZQ R
objectZZR X
)ZZX Y
DBNullZZY _
.ZZ_ `
ValueZZ` e
)ZZe f
,ZZf g
new[[ 
SqlParameter[[ $
([[$ %
$str[[% ;
,[[; <
contrato[[= E
.[[E F
ContratoFechaInicio[[F Y
??[[Z \
DateTime[[] e
.[[e f
Now[[f i
)[[i j
,[[j k
new\\ 
SqlParameter\\ $
(\\$ %
$str\\% 8
,\\8 9
contrato\\: B
.\\B C
ContratoFechaFin\\C S
??\\T V
(\\W X
object\\X ^
)\\^ _
DBNull\\_ e
.\\e f
Value\\f k
)\\k l
,\\l m
new]] 
SqlParameter]] $
(]]$ %
$str]]% 7
,]]7 8
contrato]]9 A
.]]A B
ContratoSalario]]B Q
)]]Q R
,]]R S
new^^ 
SqlParameter^^ $
(^^$ %
$str^^% 6
,^^6 7
contrato^^8 @
.^^@ A
ContratoEstado^^A O
??^^P R
(^^S T
object^^T Z
)^^Z [
DBNull^^[ a
.^^a b
Value^^b g
)^^g h
}__ 
;__ 
awaitaa 
_contextaa 
.aa 
Databaseaa '
.aa' (
ExecuteSqlRawAsyncaa( :
(aa: ;
$str	bb ⁄
,
bb⁄ €

parametroscc 
)cc 
;cc  
varee 
ultimoHistorialee #
=ee$ %
awaitee& +
_contextee, 4
.ee4 5
Setee5 8
<ee8 9
HistorialContratoee9 J
>eeJ K
(eeK L
)eeL M
.ff 
OrderByDescendingff &
(ff& '
hff' (
=>ff) +
hff, -
.ff- .
HistorialCodigoff. =
)ff= >
.gg 
FirstOrDefaultAsyncgg (
(gg( )
)gg) *
;gg* +
inthh 
nuevoNumerohh 
=hh  !
$numhh" #
;hh# $
ifii 
(ii 
ultimoHistorialii #
!=ii$ &
nullii' +
&&ii, .
intii/ 2
.ii2 3
TryParseii3 ;
(ii; <
ultimoHistorialii< K
.iiK L
HistorialCodigoiiL [
,ii[ \
outii] `
intiia d
ultimoNumeroiie q
)iiq r
)iir s
nuevoNumerojj 
=jj  !
ultimoNumerojj" .
+jj/ 0
$numjj1 2
;jj2 3
stringkk  
nuevoHistorialCodigokk +
=kk, -
nuevoNumerokk. 9
.kk9 :
ToStringkk: B
(kkB C
$strkkC G
)kkG H
;kkH I
varmm 
	historialmm 
=mm 
newmm  #
HistorialContratomm$ 5
{nn 
HistorialCodigooo #
=oo$ % 
nuevoHistorialCodigooo& :
,oo: ;
ContratoCodigopp "
=pp# $
contratopp% -
.pp- .
ContratoCodigopp. <
,pp< =
EventoCodigoqq  
=qq! "
$strqq# )
,qq) *
HistorialMotivorr #
=rr$ %
motivorr& ,
,rr, -
HistorialDetalless $
=ss% &
$strss' A
,ssA B
HistorialFechatt "
=tt# $
DateTimett% -
.tt- .
Nowtt. 1
}uu 
;uu 
awaitww 
RegistrarHistorialww (
(ww( )
	historialww) 2
)ww2 3
;ww3 4
}xx 
catchyy 
(yy 
SqlExceptionyy 
exyy  "
)yy" #
{zz 
throw{{ 
new{{ 
DatabaseException{{ +
({{+ ,
$"{{, .
$str{{. V
{{{V W
ex{{W Y
.{{Y Z
Message{{Z a
}{{a b
"{{b c
){{c d
;{{d e
}|| 
catch}} 
(}} 
	Exception}} 
ex}} 
)}}  
{~~ 
throw 
new 
AppException &
(& '
$str' 4
+5 6
ex7 9
.9 :
Message: A
,A B
exC E
)E F
;F G
}
ÄÄ 
}
ÅÅ 	
public
ÉÉ 
async
ÉÉ 
Task
ÉÉ 
EliminarContrato
ÉÉ *
(
ÉÉ* +
string
ÉÉ+ 1
contratoCodigo
ÉÉ2 @
)
ÉÉ@ A
{
ÑÑ 	
try
ÖÖ 
{
ÜÜ 
var
áá 
	parametro
áá 
=
áá 
new
áá  #
SqlParameter
áá$ 0
(
áá0 1
$str
áá1 B
,
ááB C
contratoCodigo
ááD R
)
ááR S
;
ááS T
await
àà 
_context
àà 
.
àà 
Database
àà '
.
àà' ( 
ExecuteSqlRawAsync
àà( :
(
àà: ;
$str
àà; m
,
ààm n
	parametro
àào x
)
ààx y
;
àày z
}
ââ 
catch
ää 
(
ää 
SqlException
ää 
ex
ää  "
)
ää" #
{
ãã 
throw
åå 
new
åå 
DatabaseException
åå +
(
åå+ ,
$"
åå, .
$str
åå. U
{
ååU V
ex
ååV X
.
ååX Y
Message
ååY `
}
åå` a
"
ååa b
)
ååb c
;
ååc d
}
çç 
catch
éé 
(
éé 
	Exception
éé 
ex
éé 
)
éé  
{
èè 
throw
êê 
new
êê 
AppException
êê &
(
êê& '
$str
êê' 4
+
êê5 6
ex
êê7 9
.
êê9 :
Message
êê: A
,
êêA B
ex
êêC E
)
êêE F
;
êêF G
}
ëë 
}
íí 	
public
ìì 
async
ìì 
Task
ìì 
<
ìì 
bool
ìì 
>
ìì #
ExisteContratoVigente
ìì  5
(
ìì5 6
string
ìì6 <
empleadoCodigo
ìì= K
)
ììK L
{
îî 	
return
ïï 
await
ïï 
_context
ïï !
.
ïï! " 
ContratosLaborales
ïï" 4
.
ññ 
AnyAsync
ññ 
(
ññ 
c
ññ 
=>
ññ 
c
ññ  
.
ññ  !
EmpleadoCodigo
ññ! /
==
ññ0 2
empleadoCodigo
ññ3 A
&&
ññB D
c
ññE F
.
ññF G
ContratoEstado
ññG U
==
ññV X
$str
ññY \
)
ññ\ ]
;
ññ] ^
}
óó 	
public
ôô 
async
ôô 
Task
ôô 
<
ôô 
bool
ôô 
>
ôô "
ExisteEmpleadoActivo
ôô  4
(
ôô4 5
string
ôô5 ;
empleadoCodigo
ôô< J
)
ôôJ K
{
öö 	
return
õõ 
await
õõ 
_context
õõ !
.
õõ! "
	Empleados
õõ" +
.
úú 
AnyAsync
úú 
(
úú 
e
úú 
=>
úú 
e
úú  
.
úú  !
EmpleadoCodigo
úú! /
==
úú0 2
empleadoCodigo
úú3 A
&&
úúB D
e
úúE F
.
úúF G
EmpleadoEstado
úúG U
==
úúV X
$str
úúY \
)
úú\ ]
;
úú] ^
}
ùù 	
public
üü 
async
üü 
Task
üü 
<
üü 
ContratoLaboral
üü )
?
üü) *
>
üü* +
ObtenerContrato
üü, ;
(
üü; <
string
üü< B
contratoCodigo
üüC Q
)
üüQ R
{
†† 	
return
°° 
await
°° 
_context
°° !
.
°°! " 
ContratosLaborales
°°" 4
.
¢¢ 
AsNoTracking
¢¢ 
(
¢¢ 
)
¢¢ 
.
££ !
FirstOrDefaultAsync
££ $
(
££$ %
c
££% &
=>
££' )
c
££* +
.
££+ ,
ContratoCodigo
££, :
.
££: ;
Trim
££; ?
(
££? @
)
££@ A
==
££B D
contratoCodigo
££E S
.
££S T
Trim
££T X
(
££X Y
)
££Y Z
)
££Z [
;
££[ \
}
§§ 	
public
¶¶ 
async
¶¶ 
Task
¶¶  
RegistrarHistorial
¶¶ ,
(
¶¶, -
HistorialContrato
¶¶- >
	historial
¶¶? H
)
¶¶H I
{
ßß 	"
ContratoLaboralRules
®®  
.
®®  !$
ValidarMotivoHistorial
®®! 7
(
®®7 8
	historial
®®8 A
.
®®A B
HistorialMotivo
®®B Q
)
®®Q R
;
®®R S
var
©© 

parametros
©© 
=
©© 
new
©©  
[
©©  !
]
©©! "
{
™™ 
new
´´ 
SqlParameter
´´  
(
´´  !
$str
´´! 3
,
´´3 4
	historial
´´5 >
.
´´> ?
HistorialCodigo
´´? N
)
´´N O
,
´´O P
new
¨¨ 
SqlParameter
¨¨  
(
¨¨  !
$str
¨¨! 2
,
¨¨2 3
	historial
¨¨4 =
.
¨¨= >
ContratoCodigo
¨¨> L
)
¨¨L M
,
¨¨M N
new
≠≠ 
SqlParameter
≠≠  
(
≠≠  !
$str
≠≠! 0
,
≠≠0 1
	historial
≠≠2 ;
.
≠≠; <
EventoCodigo
≠≠< H
)
≠≠H I
,
≠≠I J
new
ÆÆ 
SqlParameter
ÆÆ  
(
ÆÆ  !
$str
ÆÆ! 3
,
ÆÆ3 4
	historial
ÆÆ5 >
.
ÆÆ> ?
HistorialMotivo
ÆÆ? N
??
ÆÆO Q
(
ÆÆR S
object
ÆÆS Y
)
ÆÆY Z
DBNull
ÆÆZ `
.
ÆÆ` a
Value
ÆÆa f
)
ÆÆf g
,
ÆÆg h
new
ØØ 
SqlParameter
ØØ  
(
ØØ  !
$str
ØØ! 4
,
ØØ4 5
	historial
ØØ6 ?
.
ØØ? @
HistorialDetalle
ØØ@ P
??
ØØQ S
(
ØØT U
object
ØØU [
)
ØØ[ \
DBNull
ØØ\ b
.
ØØb c
Value
ØØc h
)
ØØh i
,
ØØi j
new
∞∞ 
SqlParameter
∞∞  
(
∞∞  !
$str
∞∞! 2
,
∞∞2 3
	historial
∞∞4 =
.
∞∞= >
HistorialFecha
∞∞> L
)
∞∞L M
}
±± 
;
±± 
await
≥≥ 
_context
≥≥ 
.
≥≥ 
Database
≥≥ #
.
≥≥# $ 
ExecuteSqlRawAsync
≥≥$ 6
(
≥≥6 7
$str¥¥ ú
,¥¥ú ù

parametros
µµ 
)
∂∂ 
;
∂∂ 
}
∑∑ 	
public
∏∏ 
async
∏∏ 
Task
∏∏ 
<
∏∏ 
string
∏∏  
>
∏∏  !#
GenerarCodigoContrato
∏∏" 7
(
∏∏7 8
)
∏∏8 9
{
ππ 	
var
∫∫ 
ultimoCodigo
∫∫ 
=
∫∫ 
await
∫∫ $
_context
∫∫% -
.
∫∫- . 
ContratosLaborales
∫∫. @
.
ªª 
Where
ªª 
(
ªª 
c
ªª 
=>
ªª 
c
ªª 
.
ªª 
ContratoCodigo
ªª ,
.
ªª, -

StartsWith
ªª- 7
(
ªª7 8
$str
ªª8 =
)
ªª= >
)
ªª> ?
.
ºº 
OrderByDescending
ºº "
(
ºº" #
c
ºº# $
=>
ºº% '
c
ºº( )
.
ºº) *
ContratoCodigo
ºº* 8
)
ºº8 9
.
ΩΩ 
Select
ΩΩ 
(
ΩΩ 
c
ΩΩ 
=>
ΩΩ 
c
ΩΩ 
.
ΩΩ 
ContratoCodigo
ΩΩ -
)
ΩΩ- .
.
ææ !
FirstOrDefaultAsync
ææ $
(
ææ$ %
)
ææ% &
;
ææ& '
if
¿¿ 
(
¿¿ 
string
¿¿ 
.
¿¿ 
IsNullOrEmpty
¿¿ $
(
¿¿$ %
ultimoCodigo
¿¿% 1
)
¿¿1 2
)
¿¿2 3
{
¡¡ 
return
¬¬ 
$str
¬¬ 
;
¬¬ 
}
√√ 
else
ƒƒ 
{
≈≈ 
string
∆∆ 
	numeroStr
∆∆  
=
∆∆! "
ultimoCodigo
∆∆# /
.
∆∆/ 0
	Substring
∆∆0 9
(
∆∆9 :
$num
∆∆: ;
,
∆∆; <
$num
∆∆= >
)
∆∆> ?
;
∆∆? @
int
«« 
numeroActual
««  
=
««! "
int
««# &
.
««& '
Parse
««' ,
(
««, -
	numeroStr
««- 6
)
««6 7
;
««7 8
numeroActual
»» 
++
»» 
;
»» 
return
…… 
$"
…… 
$str
…… 
{
…… 
numeroActual
…… )
:
……) *
$str
……* ,
}
……, -
"
……- .
;
……. /
}
   
}
ÀÀ 	
public
ÃÃ 
async
ÃÃ 
Task
ÃÃ 
<
ÃÃ 
IEnumerable
ÃÃ %
<
ÃÃ% &
ContratoResumen
ÃÃ& 5
>
ÃÃ5 6
>
ÃÃ6 7$
ListarContratosPorTipo
ÃÃ8 N
(
ÃÃN O
)
ÃÃO P
{
ÕÕ 	
return
ŒŒ 
await
ŒŒ 
_context
ŒŒ !
.
ŒŒ! "
TiposContrato
ŒŒ" /
.
œœ 
Select
œœ 
(
œœ 
t
œœ 
=>
œœ 
new
œœ  
ContratoResumen
œœ! 0
{
–– 
Codigo
—— 
=
—— 
(
—— 
t
—— 
.
——   
TipoContratoCodigo
——  2
??
——3 5
string
——6 <
.
——< =
Empty
——= B
)
——B C
.
——C D
Trim
——D H
(
——H I
)
——I J
,
——J K
Descripcion
““ 
=
““  !
(
““" #
t
““# $
.
““$ %%
TipoContratoDescripcion
““% <
??
““= ?
string
““@ F
.
““F G
Empty
““G L
)
““L M
.
““M N
Trim
““N R
(
““R S
)
““S T
}
”” 
)
”” 
.
‘‘ 
OrderBy
‘‘ 
(
‘‘ 
cr
‘‘ 
=>
‘‘ 
cr
‘‘ !
.
‘‘! "
Descripcion
‘‘" -
)
‘‘- .
.
’’ 
ToListAsync
’’ 
(
’’ 
)
’’ 
;
’’ 
}
÷÷ 	
public
ÿÿ 
async
ÿÿ 
Task
ÿÿ 
<
ÿÿ 
IEnumerable
ÿÿ %
<
ÿÿ% &
ContratoResumen
ÿÿ& 5
>
ÿÿ5 6
>
ÿÿ6 7)
ListarContratosPorModalidad
ÿÿ8 S
(
ÿÿS T
)
ÿÿT U
{
ŸŸ 	
return
⁄⁄ 
await
⁄⁄ 
_context
⁄⁄ !
.
⁄⁄! " 
ContratosLaborales
⁄⁄" 4
.
€€ 
Where
€€ 
(
€€ 
c
€€ 
=>
€€ 
c
€€ 
.
€€ 
ContratoEstado
€€ ,
==
€€- /
$str
€€0 3
)
€€3 4
.
‹‹ 
Join
‹‹ 
(
‹‹ 
_context
‹‹ 
.
‹‹ 
ModalidadesPago
‹‹ .
,
‹‹. /
c
›› 
=>
›› 
c
›› 
.
›› 
ModalidadCodigo
›› ,
,
››, -
m
ﬁﬁ 
=>
ﬁﬁ 
m
ﬁﬁ 
.
ﬁﬁ 
ModalidadCodigo
ﬁﬁ ,
,
ﬁﬁ, -
(
ﬂﬂ 
c
ﬂﬂ 
,
ﬂﬂ 
m
ﬂﬂ 
)
ﬂﬂ 
=>
ﬂﬂ 
new
ﬂﬂ  #
ContratoResumen
ﬂﬂ$ 3
{
‡‡ 
Codigo
··  
=
··! "
(
··# $
c
··$ %
.
··% &
ModalidadCodigo
··& 5
??
··6 8
string
··9 ?
.
··? @
Empty
··@ E
)
··E F
.
··F G
Trim
··G K
(
··K L
)
··L M
,
··M N
Descripcion
‚‚ %
=
‚‚& '
(
‚‚( )
m
‚‚) *
.
‚‚* +"
ModalidadDescripcion
‚‚+ ?
??
‚‚@ B
string
‚‚C I
.
‚‚I J
Empty
‚‚J O
)
‚‚O P
.
‚‚P Q
Trim
‚‚Q U
(
‚‚U V
)
‚‚V W
}
„„ 
)
„„ 
.
‰‰ 
Distinct
‰‰ 
(
‰‰ 
)
‰‰ 
.
ÂÂ 
OrderBy
ÂÂ 
(
ÂÂ 
cr
ÂÂ 
=>
ÂÂ 
cr
ÂÂ !
.
ÂÂ! "
Descripcion
ÂÂ" -
)
ÂÂ- .
.
ÊÊ 
ToListAsync
ÊÊ 
(
ÊÊ 
)
ÊÊ 
;
ÊÊ 
}
ÁÁ 	
public
ÈÈ 
async
ÈÈ 
Task
ÈÈ 
<
ÈÈ 
IEnumerable
ÈÈ %
<
ÈÈ% &
ContratoResumen
ÈÈ& 5
>
ÈÈ5 6
>
ÈÈ6 7'
ListarContratosPorJornada
ÈÈ8 Q
(
ÈÈQ R
)
ÈÈR S
{
ÍÍ 	
return
ÎÎ 
await
ÎÎ 
_context
ÎÎ !
.
ÎÎ! "
JornadasLaborales
ÎÎ" 3
.
ÏÏ 
Select
ÏÏ 
(
ÏÏ 
j
ÏÏ 
=>
ÏÏ 
new
ÏÏ  
ContratoResumen
ÏÏ! 0
{
ÌÌ 
Codigo
ÓÓ 
=
ÓÓ 
(
ÓÓ 
j
ÓÓ 
.
ÓÓ  
JornadaCodigo
ÓÓ  -
??
ÓÓ. 0
string
ÓÓ1 7
.
ÓÓ7 8
Empty
ÓÓ8 =
)
ÓÓ= >
.
ÓÓ> ?
Trim
ÓÓ? C
(
ÓÓC D
)
ÓÓD E
,
ÓÓE F
Descripcion
ÔÔ 
=
ÔÔ  !
(
ÔÔ" #
j
ÔÔ# $
.
ÔÔ$ % 
JornadaDescripcion
ÔÔ% 7
??
ÔÔ8 :
string
ÔÔ; A
.
ÔÔA B
Empty
ÔÔB G
)
ÔÔG H
.
ÔÔH I
Trim
ÔÔI M
(
ÔÔM N
)
ÔÔN O
}
 
)
 
.
ÒÒ 
OrderBy
ÒÒ 
(
ÒÒ 
cr
ÒÒ 
=>
ÒÒ 
cr
ÒÒ !
.
ÒÒ! "
Descripcion
ÒÒ" -
)
ÒÒ- .
.
ÚÚ 
ToListAsync
ÚÚ 
(
ÚÚ 
)
ÚÚ 
;
ÚÚ 
}
ÛÛ 	
public
ıı 
async
ıı 
Task
ıı 
<
ıı 
IEnumerable
ıı %
<
ıı% &
ContratoResumen
ıı& 5
>
ıı5 6
>
ıı6 7&
ListarContratosPorEstado
ıı8 P
(
ııP Q
)
ııQ R
{
ˆˆ 	
return
˜˜ 
await
˜˜ 
_context
˜˜ !
.
˜˜! " 
ContratosLaborales
˜˜" 4
.
¯¯ 
Select
¯¯ 
(
¯¯ 
c
¯¯ 
=>
¯¯ 
new
¯¯  
ContratoResumen
¯¯! 0
{
˘˘ 
Codigo
˙˙ 
=
˙˙ 
(
˙˙ 
c
˙˙ 
.
˙˙  
ContratoEstado
˙˙  .
??
˙˙/ 1
string
˙˙2 8
.
˙˙8 9
Empty
˙˙9 >
)
˙˙> ?
.
˙˙? @
Trim
˙˙@ D
(
˙˙D E
)
˙˙E F
,
˙˙F G
Descripcion
˚˚ 
=
˚˚  !
c
˚˚" #
.
˚˚# $
ContratoEstado
˚˚$ 2
}
¸¸ 
)
¸¸ 
.
˝˝ 
Distinct
˝˝ 
(
˝˝ 
)
˝˝ 
.
˛˛ 
OrderBy
˛˛ 
(
˛˛ 
cr
˛˛ 
=>
˛˛ 
cr
˛˛ !
.
˛˛! "
Descripcion
˛˛" -
)
˛˛- .
.
ˇˇ 
ToListAsync
ˇˇ 
(
ˇˇ 
)
ˇˇ 
;
ˇˇ 
}
ÄÄ 	
public
ÇÇ 
async
ÇÇ 
Task
ÇÇ 
<
ÇÇ 
IEnumerable
ÇÇ %
<
ÇÇ% &
HistorialDetalle
ÇÇ& 6
>
ÇÇ6 7
>
ÇÇ7 8%
ListarHistorialDetalles
ÇÇ9 P
(
ÇÇP Q
)
ÇÇQ R
{
ÉÉ 	
return
ÑÑ 
await
ÑÑ 
_context
ÑÑ !
.
ÑÑ! " 
HistorialContratos
ÑÑ" 4
.
ÖÖ 
OrderByDescending
ÖÖ "
(
ÖÖ" #
h
ÖÖ# $
=>
ÖÖ% '
h
ÖÖ( )
.
ÖÖ) *
HistorialFecha
ÖÖ* 8
)
ÖÖ8 9
.
ÜÜ 
Select
ÜÜ 
(
ÜÜ 
h
ÜÜ 
=>
ÜÜ 
new
ÜÜ  
HistorialDetalle
ÜÜ! 1
{
áá 
ContratoCodigo
àà "
=
àà# $
(
àà% &
h
àà& '
.
àà' (
ContratoCodigo
àà( 6
??
àà7 9
string
àà: @
.
àà@ A
Empty
ààA F
)
ààF G
.
ààG H
Trim
ààH L
(
ààL M
)
ààM N
,
ààN O
Detalle
ââ 
=
ââ 
(
ââ 
h
ââ  
.
ââ  !
HistorialDetalle
ââ! 1
??
ââ2 4
string
ââ5 ;
.
ââ; <
Empty
ââ< A
)
ââA B
.
ââB C
Trim
ââC G
(
ââG H
)
ââH I
,
ââI J
Motivo
ää 
=
ää 
(
ää 
h
ää 
.
ää  
HistorialMotivo
ää  /
??
ää0 2
string
ää3 9
.
ää9 :
Empty
ää: ?
)
ää? @
.
ää@ A
Trim
ääA E
(
ääE F
)
ääF G
,
ääG H
HistorialFecha
ãã "
=
ãã# $
h
ãã% &
.
ãã& '
HistorialFecha
ãã' 5
}
åå 
)
åå 
.
çç 
ToListAsync
çç 
(
çç 
)
çç 
;
çç 
}
éé 	
public
êê 
async
êê 
Task
êê 
SuspenderContrato
êê +
(
êê+ ,
string
êê, 2
contratoCodigo
êê3 A
,
êêA B
string
êêC I
nuevoEstado
êêJ U
,
êêU V
string
êêW ]
motivo
êê^ d
)
êêd e
{
ëë 	
var
íí 
contrato
íí 
=
íí 
await
íí  
_context
íí! )
.
íí) * 
ContratosLaborales
íí* <
.
ìì	 
!
FirstOrDefaultAsync
ìì
 
(
ìì 
c
ìì 
=>
ìì  "
c
ìì# $
.
ìì$ %
ContratoCodigo
ìì% 3
.
ìì3 4
Trim
ìì4 8
(
ìì8 9
)
ìì9 :
==
ìì; =
contratoCodigo
ìì> L
.
ììL M
Trim
ììM Q
(
ììQ R
)
ììR S
)
ììS T
;
ììT U
if
îî 
(
îî 
contrato
îî 
==
îî 
null
îî  
)
îî  !
throw
ïï 
new
ïï "
KeyNotFoundException
ïï .
(
ïï. /
$str
ïï/ H
)
ïïH I
;
ïïI J"
ContratoLaboralRules
ññ  
.
ññ  !!
ValidarReactivacion
ññ! 4
(
ññ4 5
contrato
ññ5 =
.
ññ= >
ContratoEstado
ññ> L
,
ññL M
nuevoEstado
ññN Y
)
ññY Z
;
ññZ [
string
óó 
eventoCodigo
óó 
;
óó  
string
òò 
detalle
òò 
;
òò 
if
ôô 
(
ôô 
contrato
ôô 
.
ôô 
ContratoEstado
ôô '
.
ôô' (
Trim
ôô( ,
(
ôô, -
)
ôô- .
==
ôô/ 1
$str
ôô2 5
&&
ôô6 8
nuevoEstado
ôô9 D
.
ôôD E
Trim
ôôE I
(
ôôI J
)
ôôJ K
==
ôôL N
$str
ôôO R
)
ôôR S
{
öö 
eventoCodigo
õõ 
=
õõ 
$str
õõ %
;
õõ% &
detalle
úú 
=
úú 
$str
úú 4
;
úú4 5
}
ùù 
else
ûû 
if
ûû 
(
ûû 
contrato
ûû 
.
ûû 
ContratoEstado
ûû ,
.
ûû, -
Trim
ûû- 1
(
ûû1 2
)
ûû2 3
==
ûû4 6
$str
ûû7 :
&&
ûû; =
nuevoEstado
ûû> I
.
ûûI J
Trim
ûûJ N
(
ûûN O
)
ûûO P
==
ûûQ S
$str
ûûT W
)
ûûW X
{
üü 
eventoCodigo
†† 
=
†† 
$str
†† %
;
††% &
detalle
°° 
=
°° 
$str
°° 2
;
°°2 3
}
¢¢ 
else
££ 
{
§§ 
throw
•• 
new
•• '
InvalidOperationException
•• 3
(
••3 4
$str
••4 o
)
••o p
;
••p q
}
¶¶ 
var
ßß 
ultimoHistorial
ßß 
=
ßß  !
await
ßß" '
_context
ßß( 0
.
ßß0 1
Set
ßß1 4
<
ßß4 5
HistorialContrato
ßß5 F
>
ßßF G
(
ßßG H
)
ßßH I
.
®® 
OrderByDescending
®® "
(
®®" #
h
®®# $
=>
®®% '
h
®®( )
.
®®) *
HistorialCodigo
®®* 9
)
®®9 :
.
©© !
FirstOrDefaultAsync
©© $
(
©©$ %
)
©©% &
;
©©& '
int
™™ 
nuevoNumero
™™ 
=
™™ 
$num
™™ 
;
™™  
if
´´ 
(
´´ 
ultimoHistorial
´´ 
!=
´´  "
null
´´# '
&&
´´( *
int
´´+ .
.
´´. /
TryParse
´´/ 7
(
´´7 8
ultimoHistorial
´´8 G
.
´´G H
HistorialCodigo
´´H W
,
´´W X
out
´´Y \
int
´´] `
ultimoNumero
´´a m
)
´´m n
)
´´n o
nuevoNumero
¨¨ 
=
¨¨ 
ultimoNumero
¨¨ *
+
¨¨+ ,
$num
¨¨- .
;
¨¨. /
string
≠≠ "
nuevoHistorialCodigo
≠≠ '
=
≠≠( )
nuevoNumero
≠≠* 5
.
≠≠5 6
ToString
≠≠6 >
(
≠≠> ?
$str
≠≠? C
)
≠≠C D
;
≠≠D E
var
ÆÆ 
	historial
ÆÆ 
=
ÆÆ 
new
ÆÆ 
HistorialContrato
ÆÆ  1
{
ØØ 
HistorialCodigo
∞∞ 
=
∞∞  !"
nuevoHistorialCodigo
∞∞" 6
,
∞∞6 7
ContratoCodigo
±± 
=
±±  
contrato
±±! )
.
±±) *
ContratoCodigo
±±* 8
,
±±8 9
EventoCodigo
≤≤ 
=
≤≤ 
eventoCodigo
≤≤ +
,
≤≤+ ,
HistorialMotivo
≥≥ 
=
≥≥  !
motivo
≥≥" (
,
≥≥( )
HistorialDetalle
¥¥  
=
¥¥! "
detalle
¥¥# *
,
¥¥* +
HistorialFecha
µµ 
=
µµ  
DateTime
µµ! )
.
µµ) *
Now
µµ* -
}
∂∂ 
;
∂∂ 
await
∑∑  
RegistrarHistorial
∑∑ $
(
∑∑$ %
	historial
∑∑% .
)
∑∑. /
;
∑∑/ 0
var
∏∏ 

parameters
∏∏ 
=
∏∏ 
new
∏∏  
[
∏∏  !
]
∏∏! "
{
ππ 
new
∫∫ 
SqlParameter
∫∫ 
(
∫∫ 
$str
∫∫ .
,
∫∫. /
contratoCodigo
∫∫0 >
)
∫∫> ?
,
∫∫? @
new
ªª 
SqlParameter
ªª 
(
ªª 
$str
ªª +
,
ªª+ ,
nuevoEstado
ªª- 8
.
ªª8 9
Trim
ªª9 =
(
ªª= >
)
ªª> ?
)
ªª? @
}
ºº 
;
ºº 
await
ΩΩ 
_context
ΩΩ 
.
ΩΩ 
Database
ΩΩ #
.
ΩΩ# $ 
ExecuteSqlRawAsync
ΩΩ$ 6
(
ΩΩ6 7
$str
ææ M
,
ææM N

parameters
øø 
)
¿¿ 
;
¿¿ 
}
¡¡ 	
public
¬¬ 
async
¬¬ 
Task
¬¬ 
<
¬¬ 
IEnumerable
¬¬ %
<
¬¬% &
object
¬¬& ,
>
¬¬, -
>
¬¬- .(
ListarEmpleadosSinContrato
¬¬/ I
(
¬¬I J
)
¬¬J K
{
√√ 	
var
ƒƒ 
	empleados
ƒƒ 
=
ƒƒ 
await
ƒƒ !
_context
ƒƒ" *
.
ƒƒ* +
	Empleados
ƒƒ+ 4
.
≈≈ 
AsNoTracking
≈≈ 
(
≈≈ 
)
≈≈ 
.
∆∆ 
Where
∆∆ 
(
∆∆ 
e
∆∆ 
=>
∆∆ 
!
«« 
_context
«« 
.
««  
ContratosLaborales
«« 0
.
»» 
AsNoTracking
»» %
(
»»% &
)
»»& '
.
…… 
Any
…… 
(
…… 
c
…… 
=>
…… !
c
   
.
   
EmpleadoCodigo
   ,
.
  , -
Trim
  - 1
(
  1 2
)
  2 3
==
  4 6
e
  7 8
.
  8 9
EmpleadoCodigo
  9 G
.
  G H
Trim
  H L
(
  L M
)
  M N
&&
  O Q
(
ÀÀ 
c
ÀÀ 
.
ÀÀ 
ContratoEstado
ÀÀ -
.
ÀÀ- .
Trim
ÀÀ. 2
(
ÀÀ2 3
)
ÀÀ3 4
==
ÀÀ5 7
$str
ÀÀ8 ;
||
ÀÀ< >
c
ÀÀ? @
.
ÀÀ@ A
ContratoEstado
ÀÀA O
.
ÀÀO P
Trim
ÀÀP T
(
ÀÀT U
)
ÀÀU V
==
ÀÀW Y
$str
ÀÀZ ]
)
ÀÀ] ^
)
ÀÀ^ _
)
ÃÃ 
.
ÕÕ 
Select
ÕÕ 
(
ÕÕ 
e
ÕÕ 
=>
ÕÕ 
new
ÕÕ  
{
ŒŒ 
EmpleadoCodigo
œœ "
=
œœ# $
e
œœ% &
.
œœ& '
EmpleadoCodigo
œœ' 5
.
œœ5 6
Trim
œœ6 :
(
œœ: ;
)
œœ; <
,
œœ< =
EmpleadoNombre
–– "
=
––# $
(
––% &
e
––& '
.
––' (
EmpleadoNombre
––( 6
+
––7 8
$str
––9 <
+
––= >
e
––? @
.
––@ A
EmpleadoApellido
––A Q
)
––Q R
.
––R S
Trim
––S W
(
––W X
)
––X Y
}
—— 
)
—— 
.
““ 
ToListAsync
““ 
(
““ 
)
““ 
;
““ 
return
‘‘ 
	empleados
‘‘ 
;
‘‘ 
}
’’ 	
}
÷÷ 
}◊◊ Î±
qC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina.Infrastructure\Persistence\AppDbContext.cs
	namespace 	
Nomina
 
. 
Infrastructure 
.  
Persistence  +
{ 
public 

class 
AppDbContext 
: 
	DbContext  )
{ 
public 
AppDbContext 
( 
DbContextOptions ,
<, -
AppDbContext- 9
>9 :
options; B
)B C
:		 
base		 
(		 
options		 
)		 
{

 	
} 	
public 
DbSet 
< 
Cargo 
> 
Cargos "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
DbSet 
< 
Departamento !
>! "
Departamentos# 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
DbSet 
< 
Empleado 
> 
	Empleados (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
DbSet 
< 
JornadaLaboral #
># $
JornadasLaborales% 6
{7 8
get9 <
;< =
set> A
;A B
}C D
public 
DbSet 
< 
ModalidadPago "
>" #
ModalidadesPago$ 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
public 
DbSet 
< 
TipoContrato !
>! "
TiposContrato# 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
DbSet 
< 
Usuario 
> 
Usuarios &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
DbSet 
< 
ContratoLaboral $
>$ %
ContratosLaborales& 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
public 
DbSet 
< 
EventoContrato #
># $
EventosContrato% 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
public 
DbSet 
< 
HistorialContrato &
>& '
HistorialContratos( :
{; <
get= @
;@ A
setB E
;E F
}G H
public 
DbSet 
< 
PeriodoNomina "
>" #
PeriodosNomina$ 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
DbSet 
< 
Nominas 
> 
Nominas %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
DbSet 
< 
DescuentoAdicional '
>' (!
DescuentosAdicionales) >
{? @
getA D
;D E
setF I
;I J
}K L
public 
DbSet 
< 
ParametroSistema %
>% &
ParametrosSistema' 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
public 
DbSet 
< 
ConceptoNomina #
># $
ConceptosNomina% 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
public	 
DbSet 
< 
ContratoResumen %
>% &
ContratosResumen' 7
{8 9
get: =
;= >
set? B
;B C
}D E
public 
DbSet 
< 
ResumenEmpleado $
>$ %
ResumenEmpleados& 6
{7 8
get9 <
;< =
set> A
;A B
}C D
=E F
nullG K
!K L
;L M
	protected!! 
override!! 
void!! 
OnModelCreating!!  /
(!!/ 0
ModelBuilder!!0 <
modelBuilder!!= I
)!!I J
{"" 	
base## 
.## 
OnModelCreating##  
(##  !
modelBuilder##! -
)##- .
;##. /
modelBuilder)) 
.)) 
Entity)) 
<))  
Cargo))  %
>))% &
())& '
entity))' -
=>)). 0
{** 
entity++ 
.++ 
ToTable++ 
(++ 
$str++ '
,++' (
$str++) .
)++. /
;++/ 0
entity,, 
.,, 
HasKey,, 
(,, 
e,, 
=>,,  "
e,,# $
.,,$ %
CargoCodigo,,% 0
),,0 1
;,,1 2
}-- 
)-- 
;-- 
modelBuilder// 
.// 
Entity// 
<//  
Departamento//  ,
>//, -
(//- .
entity//. 4
=>//5 7
{00 
entity11 
.11 
ToTable11 
(11 
$str11 .
,11. /
$str110 5
)115 6
;116 7
entity22 
.22 
HasKey22 
(22 
e22 
=>22  "
e22# $
.22$ %
DepartamentoCodigo22% 7
)227 8
;228 9
}33 
)33 
;33 
modelBuilder55 
.55 
Entity55 
<55  
Empleado55  (
>55( )
(55) *
entity55* 0
=>551 3
{66 
entity77 
.77 
ToTable77 
(77 
$str77 *
,77* +
$str77, 1
)771 2
;772 3
entity88 
.88 
HasKey88 
(88 
e88 
=>88  "
e88# $
.88$ %
EmpleadoCodigo88% 3
)883 4
;884 5
entity:: 
.:: 
HasOne:: 
(:: 
e:: 
=>::  "
e::# $
.::$ %
Departamento::% 1
)::1 2
.;; 
WithMany;; 
(;; 
d;; 
=>;;  "
d;;# $
.;;$ %
	Empleados;;% .
);;. /
.<< 
HasForeignKey<< "
(<<" #
e<<# $
=><<% '
e<<( )
.<<) *
DepartamentoCodigo<<* <
)<<< =
.== 
OnDelete== 
(== 
DeleteBehavior== ,
.==, -
Restrict==- 5
)==5 6
;==6 7
entity?? 
.?? 
HasOne?? 
(?? 
e?? 
=>??  "
e??# $
.??$ %
Cargo??% *
)??* +
.@@ 
WithMany@@ 
(@@ 
c@@ 
=>@@  "
c@@# $
.@@$ %
	Empleados@@% .
)@@. /
.AA 
HasForeignKeyAA "
(AA" #
eAA# $
=>AA% '
eAA( )
.AA) *
CargoCodigoAA* 5
)AA5 6
.BB 
OnDeleteBB 
(BB 
DeleteBehaviorBB ,
.BB, -
RestrictBB- 5
)BB5 6
;BB6 7
}CC 
)CC 
;CC 
modelBuilderEE 
.EE 
EntityEE 
<EE  
JornadaLaboralEE  .
>EE. /
(EE/ 0
entityEE0 6
=>EE7 9
{FF 
entityGG 
.GG 
ToTableGG 
(GG 
$strGG 2
,GG2 3
$strGG4 9
)GG9 :
;GG: ;
entityHH 
.HH 
HasKeyHH 
(HH 
eHH 
=>HH  "
eHH# $
.HH$ %
JornadaCodigoHH% 2
)HH2 3
;HH3 4
}II 
)II 
;II 
modelBuilderKK 
.KK 
EntityKK 
<KK  
ModalidadPagoKK  -
>KK- .
(KK. /
entityKK/ 5
=>KK6 8
{LL 
entityMM 
.MM 
ToTableMM 
(MM 
$strMM 0
,MM0 1
$strMM2 7
)MM7 8
;MM8 9
entityNN 
.NN 
HasKeyNN 
(NN 
eNN 
=>NN  "
eNN# $
.NN$ %
ModalidadCodigoNN% 4
)NN4 5
;NN5 6
}OO 
)OO 
;OO 
modelBuilderQQ 
.QQ 
EntityQQ 
<QQ  
TipoContratoQQ  ,
>QQ, -
(QQ- .
entityQQ. 4
=>QQ5 7
{RR 
entitySS 
.SS 
ToTableSS 
(SS 
$strSS .
,SS. /
$strSS0 5
)SS5 6
;SS6 7
entityTT 
.TT 
HasKeyTT 
(TT 
eTT 
=>TT  "
eTT# $
.TT$ %
TipoContratoCodigoTT% 7
)TT7 8
;TT8 9
}UU 
)UU 
;UU 
modelBuilderWW 
.WW 
EntityWW 
<WW  
UsuarioWW  '
>WW' (
(WW( )
entityWW) /
=>WW0 2
{XX 
entityYY 
.YY 
ToTableYY 
(YY 
$strYY )
,YY) *
$strYY+ 0
)YY0 1
;YY1 2
entityZZ 
.ZZ 
HasKeyZZ 
(ZZ 
eZZ 
=>ZZ  "
eZZ# $
.ZZ$ %
UsuarioCodigoZZ% 2
)ZZ2 3
;ZZ3 4
}[[ 
)[[ 
;[[ 
modelBuilder]] 
.]] 
Entity]] 
<]]  
ContratoLaboral]]  /
>]]/ 0
(]]0 1
entity]]1 7
=>]]8 :
{^^ 
entity__ 
.__ 
ToTable__ 
(__ 
$str__ 3
,__3 4
$str__5 :
)__: ;
;__; <
entity`` 
.`` 
HasKey`` 
(`` 
e`` 
=>``  "
e``# $
.``$ %
ContratoCodigo``% 3
)``3 4
;``4 5
entitybb 
.bb 
HasOnebb 
(bb 
ebb 
=>bb  "
ebb# $
.bb$ %
Empleadobb% -
)bb- .
.cc 
WithManycc 
(cc 
empcc !
=>cc" $
empcc% (
.cc( )
ContratosLaboralescc) ;
)cc; <
.dd 
HasForeignKeydd "
(dd" #
edd# $
=>dd% '
edd( )
.dd) *
EmpleadoCodigodd* 8
)dd8 9
.ee 
OnDeleteee 
(ee 
DeleteBehavioree ,
.ee, -
Restrictee- 5
)ee5 6
;ee6 7
entitygg 
.gg 
HasOnegg 
(gg 
egg 
=>gg  "
egg# $
.gg$ %
TipoContratogg% 1
)gg1 2
.hh 
WithManyhh 
(hh 
thh 
=>hh  "
thh# $
.hh$ %
ContratosLaboraleshh% 7
)hh7 8
.ii 
HasForeignKeyii "
(ii" #
eii# $
=>ii% '
eii( )
.ii) *
TipoContratoCodigoii* <
)ii< =
.jj 
OnDeletejj 
(jj 
DeleteBehaviorjj ,
.jj, -
Restrictjj- 5
)jj5 6
;jj6 7
entityll 
.ll 
HasOnell 
(ll 
ell 
=>ll  "
ell# $
.ll$ %
	Modalidadll% .
)ll. /
.mm 
WithManymm 
(mm 
mmm 
=>mm  "
mmm# $
.mm$ %
ContratosLaboralesmm% 7
)mm7 8
.nn 
HasForeignKeynn "
(nn" #
enn# $
=>nn% '
enn( )
.nn) *
ModalidadCodigonn* 9
)nn9 :
.oo 
OnDeleteoo 
(oo 
DeleteBehavioroo ,
.oo, -
Restrictoo- 5
)oo5 6
;oo6 7
entityqq 
.qq 
HasOneqq 
(qq 
eqq 
=>qq  "
eqq# $
.qq$ %
Jornadaqq% ,
)qq, -
.rr 
WithManyrr 
(rr 
jrr 
=>rr  "
jrr# $
.rr$ %
ContratosLaboralesrr% 7
)rr7 8
.ss 
HasForeignKeyss "
(ss" #
ess# $
=>ss% '
ess( )
.ss) *
JornadaCodigoss* 7
)ss7 8
.tt 
OnDeletett 
(tt 
DeleteBehaviortt ,
.tt, -
Restricttt- 5
)tt5 6
;tt6 7
entityvv 
.vv 
HasOnevv 
(vv 
evv 
=>vv  "
evv# $
.vv$ %
Usuariovv% ,
)vv, -
.ww 
WithManyww 
(ww 
uww 
=>ww  "
uww# $
.ww$ %
ContratosLaboralesww% 7
)ww7 8
.xx 
HasForeignKeyxx "
(xx" #
exx# $
=>xx% '
exx( )
.xx) *
UsuarioCodigoxx* 7
)xx7 8
.yy 
OnDeleteyy 
(yy 
DeleteBehavioryy ,
.yy, -
Restrictyy- 5
)yy5 6
;yy6 7
}zz 
)zz 
;zz 
modelBuilder|| 
.|| 
Entity|| 
<||  
EventoContrato||  .
>||. /
(||/ 0
entity||0 6
=>||7 9
{}} 
entity~~ 
.~~ 
ToTable~~ 
(~~ 
$str~~ 0
,~~0 1
$str~~2 7
)~~7 8
;~~8 9
entity 
. 
HasKey 
( 
e 
=>  "
e# $
.$ %
EventoCodigo% 1
)1 2
;2 3
}
ÄÄ 
)
ÄÄ 
;
ÄÄ 
modelBuilder
ÇÇ 
.
ÇÇ 
Entity
ÇÇ 
<
ÇÇ  
PeriodoNomina
ÇÇ  -
>
ÇÇ- .
(
ÇÇ. /
entity
ÇÇ/ 5
=>
ÇÇ6 8
{
ÉÉ 
entity
ÑÑ 
.
ÑÑ 
ToTable
ÑÑ 
(
ÑÑ 
$str
ÑÑ /
,
ÑÑ/ 0
$str
ÑÑ1 6
)
ÑÑ6 7
;
ÑÑ7 8
entity
ÖÖ 
.
ÖÖ 
HasKey
ÖÖ 
(
ÖÖ 
e
ÖÖ 
=>
ÖÖ  "
e
ÖÖ# $
.
ÖÖ$ %
PeriodoCodigo
ÖÖ% 2
)
ÖÖ2 3
;
ÖÖ3 4
}
ÜÜ 
)
ÜÜ 
;
ÜÜ 
modelBuilder
àà 
.
àà 
Entity
àà 
<
àà  
Nominas
àà  '
>
àà' (
(
àà( )
entity
àà) /
=>
àà0 2
{
ââ 
entity
ää 
.
ää 
ToTable
ää 
(
ää 
$str
ää (
,
ää( )
$str
ää* /
)
ää/ 0
;
ää0 1
entity
ãã 
.
ãã 
HasKey
ãã 
(
ãã 
e
ãã 
=>
ãã  "
e
ãã# $
.
ãã$ %
NominaCodigo
ãã% 1
)
ãã1 2
;
ãã2 3
entity
çç 
.
çç 
HasOne
çç 
(
çç 
n
çç 
=>
çç  "
n
çç# $
.
çç$ %
Contrato
çç% -
)
çç- .
.
éé 
WithMany
éé 
(
éé 
c
éé 
=>
éé  "
c
éé# $
.
éé$ %
Nominas
éé% ,
)
éé, -
.
èè 
HasForeignKey
èè "
(
èè" #
n
èè# $
=>
èè% '
n
èè( )
.
èè) *
ContratoCodigo
èè* 8
)
èè8 9
.
êê 
OnDelete
êê 
(
êê 
DeleteBehavior
êê ,
.
êê, -
Restrict
êê- 5
)
êê5 6
;
êê6 7
entity
íí 
.
íí 
HasOne
íí 
(
íí 
n
íí 
=>
íí  "
n
íí# $
.
íí$ %
Periodo
íí% ,
)
íí, -
.
ìì 
WithMany
ìì 
(
ìì 
p
ìì 
=>
ìì  "
p
ìì# $
.
ìì$ %
Nominas
ìì% ,
)
ìì, -
.
îî 
HasForeignKey
îî "
(
îî" #
n
îî# $
=>
îî% '
n
îî( )
.
îî) *
PeriodoCodigo
îî* 7
)
îî7 8
.
ïï 
OnDelete
ïï 
(
ïï 
DeleteBehavior
ïï ,
.
ïï, -
Restrict
ïï- 5
)
ïï5 6
;
ïï6 7
}
ññ 
)
ññ 
;
ññ 
modelBuilder
òò 
.
òò 
Entity
òò 
<
òò   
DescuentoAdicional
òò  2
>
òò2 3
(
òò3 4
entity
òò4 :
=>
òò; =
{
ôô 
entity
öö 
.
öö 
ToTable
öö 
(
öö 
$str
öö 6
,
öö6 7
$str
öö8 =
)
öö= >
;
öö> ?
entity
õõ 
.
õõ 
HasKey
õõ 
(
õõ 
e
õõ 
=>
õõ  "
e
õõ# $
.
õõ$ %
DescuentoCodigo
õõ% 4
)
õõ4 5
;
õõ5 6
entity
ùù 
.
ùù 
HasOne
ùù 
(
ùù 
d
ùù 
=>
ùù  "
d
ùù# $
.
ùù$ %
Nomina
ùù% +
)
ùù+ ,
.
ûû 
WithMany
ûû 
(
ûû 
n
ûû 
=>
ûû  "
n
ûû# $
.
ûû$ %#
DescuentosAdicionales
ûû% :
)
ûû: ;
.
üü 
HasForeignKey
üü "
(
üü" #
d
üü# $
=>
üü% '
d
üü( )
.
üü) *
NominaCodigo
üü* 6
)
üü6 7
.
†† 
OnDelete
†† 
(
†† 
DeleteBehavior
†† ,
.
††, -
Restrict
††- 5
)
††5 6
;
††6 7
}
°° 
)
°° 
;
°° 
modelBuilder
££ 
.
££ 
Entity
££ 
<
££  
ParametroSistema
££  0
>
££0 1
(
££1 2
entity
££2 8
=>
££9 ;
{
§§ 
entity
•• 
.
•• 
ToTable
•• 
(
•• 
$str
•• 2
,
••2 3
$str
••4 9
)
••9 :
;
••: ;
entity
¶¶ 
.
¶¶ 
HasKey
¶¶ 
(
¶¶ 
e
¶¶ 
=>
¶¶  "
e
¶¶# $
.
¶¶$ %
ParametroCodigo
¶¶% 4
)
¶¶4 5
;
¶¶5 6
}
ßß 
)
ßß 
;
ßß 
modelBuilder
©© 
.
©© 
Entity
©© 
<
©©  
HistorialContrato
©©  1
>
©©1 2
(
©©2 3
entity
©©3 9
=>
©©: <
{
™™ 
entity
´´ 
.
´´ 
HasKey
´´ 
(
´´ 
e
´´ 
=>
´´  "
e
´´# $
.
´´$ %
HistorialCodigo
´´% 4
)
´´4 5
;
´´5 6
entity
¨¨ 
.
¨¨ 
Property
¨¨ 
(
¨¨  
e
¨¨  !
=>
¨¨" $
e
¨¨% &
.
¨¨& '
HistorialCodigo
¨¨' 6
)
¨¨6 7
.
¨¨7 8
HasMaxLength
¨¨8 D
(
¨¨D E
$num
¨¨E F
)
¨¨F G
;
¨¨G H
entity
≠≠ 
.
≠≠ 
ToTable
≠≠ 
(
≠≠ 
$str
≠≠ 3
)
≠≠3 4
;
≠≠4 5
}
ÆÆ 
)
ÆÆ 
;
ÆÆ 
modelBuilder
∞∞ 
.
∞∞ 
Entity
∞∞ 
<
∞∞  
ConceptoNomina
∞∞  .
>
∞∞. /
(
∞∞/ 0
entity
∞∞0 6
=>
∞∞7 9
{
±± 
entity
≤≤ 
.
≤≤ 
HasOne
≤≤ 
(
≤≤ 
c
≤≤ 
=>
≤≤  "
c
≤≤# $
.
≤≤$ %
Contrato
≤≤% -
)
≤≤- .
.
≥≥ 
WithMany
≥≥ 
(
≥≥ 
)
≥≥ 
.
¥¥ 
HasForeignKey
¥¥ 
(
¥¥ 
c
¥¥  
=>
¥¥! #
c
¥¥$ %
.
¥¥% &
ContratoCodigo
¥¥& 4
)
¥¥4 5
.
µµ 
OnDelete
µµ 
(
µµ 
DeleteBehavior
µµ (
.
µµ( )
Restrict
µµ) 1
)
µµ1 2
;
µµ2 3
}
∂∂ 
)
∂∂ 
;
∂∂ 
modelBuilder
∏∏ 
.
∏∏ 
Entity
∏∏ 
<
∏∏  
ConceptoNomina
∏∏  .
>
∏∏. /
(
∏∏/ 0
entity
∏∏0 6
=>
∏∏7 9
{
ππ 
entity
∫∫ 
.
∫∫ 
HasOne
∫∫ 
(
∫∫ 
c
∫∫ 
=>
∫∫  "
c
∫∫# $
.
∫∫$ %
Periodo
∫∫% ,
)
∫∫, -
.
ªª 
WithMany
ªª 
(
ªª 
)
ªª 
.
ºº 
HasForeignKey
ºº 
(
ºº 
c
ºº  
=>
ºº! #
c
ºº$ %
.
ºº% &
PeriodoCodigo
ºº& 3
)
ºº3 4
.
ΩΩ 
OnDelete
ΩΩ 
(
ΩΩ 
DeleteBehavior
ΩΩ (
.
ΩΩ( )
Restrict
ΩΩ) 1
)
ΩΩ1 2
;
ΩΩ2 3
}
ææ 
)
ææ 
;
ææ 
modelBuilder
¿¿ 
.
¿¿ 
Entity
¿¿ 
<
¿¿  
ContratoResumen
¿¿  /
>
¿¿/ 0
(
¿¿0 1
entity
¿¿1 7
=>
¿¿8 :
{
¡¡ 
entity
¬¬ 
.
¬¬ 
HasNoKey
¬¬ 
(
¬¬  
)
¬¬  !
;
¬¬! "
}
√√ 
)
√√ 
;
√√ 
modelBuilder
ƒƒ 
.
ƒƒ 
Entity
ƒƒ 
<
ƒƒ  
HistorialDetalle
ƒƒ  0
>
ƒƒ0 1
(
ƒƒ1 2
entity
ƒƒ2 8
=>
ƒƒ9 ;
{
≈≈ 
entity
∆∆ 
.
∆∆ 
HasNoKey
∆∆ 
(
∆∆  
)
∆∆  !
;
∆∆! "
}
«« 
)
«« 
;
«« 
modelBuilder
»» 
.
»» 
Entity
»» 
<
»»  
ResumenEmpleado
»»  /
>
»»/ 0
(
»»0 1
entity
»»1 7
=>
»»8 :
{
…… 
entity
   
.
   
HasNoKey
   
(
    
)
    !
;
  ! "
}
ÀÀ 
)
ÀÀ 
;
ÀÀ 
}
ÃÃ 	
}
ŒŒ 
}œœ 