Û2
QC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
QuestPDF 
. 	
Settings	 
. 
License 
= 
LicenseType '
.' (
	Community( 1
;1 2
builder 
. 
Services 
. 
AddCors 
( 
options  
=>! #
{ 
options 
. 
	AddPolicy 
( 
$str &
,& '
policy( .
=>/ 1
{ 
policy 
. 
WithOrigins 
( 
$str 2
)2 3
. 
AllowAnyMethod 
( 
) 
. 
AllowAnyHeader 
( 
) 
;  
} 
) 
; 
} 
) 
; 
string 
? 
connectionString 
= 
builder "
." #
Configuration# 0
.0 1
GetConnectionString1 D
(D E
$strE X
)X Y
;Y Z
if 
( 
string 

.
 
IsNullOrWhiteSpace 
( 
connectionString .
). /
)/ 0
{ 
throw 	
new
 %
InvalidOperationException '
(' (
$str( h
)h i
;i j
}   
builder"" 
."" 
Services"" 
."" 
AddDbContext"" 
<"" 
AppDbContext"" *
>""* +
(""+ ,
options"", 3
=>""4 6
options## 
.## 
UseSqlServer## 
(## 
connectionString## )
)##) *
)##* +
;##+ ,
builder$$ 
.$$ 
Services$$ 
.$$ 
	AddScoped$$ 
<$$ $
IReporteNominaRepository$$ 3
,$$3 4#
ReporteNominaRepository$$5 L
>$$L M
($$M N
provider$$N V
=>$$W Y
new%% #
ReporteNominaRepository%% 
(%%  
connectionString%%  0
)%%0 1
)%%1 2
;%%2 3
builder&& 
.&& 
Services&& 
.&& 
	AddScoped&& 
<&& 
INominaRepository&& ,
>&&, -
(&&- .
sp&&. 0
=>&&1 3
{'' 
var(( 
context(( 
=(( 
sp(( 
.(( 
GetRequiredService(( '
<((' (
AppDbContext((( 4
>((4 5
(((5 6
)((6 7
;((7 8
return)) 

new)) 
NominaRepository)) 
())  
context))  '
,))' (
connectionString))) 9
)))9 :
;)): ;
}** 
)** 
;** 
builder,, 
.,, 
Services,, 
.,, 
	AddScoped,, 
<,, &
IContratoLaboralRepository,, 5
>,,5 6
(,,6 7
sp,,7 9
=>,,: <
{-- 
var.. 
context.. 
=.. 
sp.. 
... 
GetRequiredService.. '
<..' (
AppDbContext..( 4
>..4 5
(..5 6
)..6 7
;..7 8
return// 

new// %
ContratoLaboralRepository// (
(//( )
context//) 0
,//0 1
connectionString//2 B
)//B C
;//C D
}00 
)00 
;00 
builder22 
.22 
Services22 
.22 
	AddScoped22 
<22 #
IContratoLaboralService22 2
,222 3"
ContratoLaboralService224 J
>22J K
(22K L
)22L M
;22M N
builder44 
.44 
Services44 
.44 
	AddScoped44 
<44 
INominaService44 )
,44) *
NominaService44+ 8
>448 9
(449 :
)44: ;
;44; <
builder55 
.55 
Services55 
.55 
	AddScoped55 
<55 !
IReporteNominaService55 0
,550 1 
ReporteNominaService552 F
>55F G
(55G H
)55H I
;55I J
builder88 
.88 
Services88 
.88 
AddControllers88 
(88  
options88  '
=>88( *
{99 
options:: 
.:: 
Filters:: 
.:: 
Add:: 
<:: 
ApiResponseFilter:: )
>::) *
(::* +
)::+ ,
;::, -
};; 
);; 
;;; 
builder== 
.== 
Services== 
.== #
AddEndpointsApiExplorer== (
(==( )
)==) *
;==* +
builder>> 
.>> 
Services>> 
.>> 
AddSwaggerGen>> 
(>> 
)>>  
;>>  !
var@@ 
app@@ 
=@@ 	
builder@@
 
.@@ 
Build@@ 
(@@ 
)@@ 
;@@ 
ifCC 
(CC 
appCC 
.CC 
EnvironmentCC 
.CC 
IsDevelopmentCC !
(CC! "
)CC" #
)CC# $
{DD 
appEE 
.EE 

UseSwaggerEE 
(EE 
)EE 
;EE 
appFF 
.FF 
UseSwaggerUIFF 
(FF 
)FF 
;FF 
}GG 
appII 
.II 
UseCorsII 
(II 
$strII 
)II 
;II 
appJJ 
.JJ 
UseMiddlewareJJ 
<JJ "
ErrorHandlerMiddlewareJJ (
>JJ( )
(JJ) *
)JJ* +
;JJ+ ,
appKK 
.KK 
UseHttpsRedirectionKK 
(KK 
)KK 
;KK 
appLL 
.LL 
UseAuthorizationLL 
(LL 
)LL 
;LL 
appMM 
.MM 
MapControllersMM 
(MM 
)MM 
;MM 
awaitNN 
appNN 	
.NN	 

RunAsyncNN
 
(NN 
)NN 
;NN â
kC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina\Middleware\ErrorHandlerMiddleware.cs
	namespace 	
Nomina
 
. 
API 
. 

Middleware 
{ 
public 

class "
ErrorHandlerMiddleware '
{ 
private		 
readonly		 
RequestDelegate		 (
_next		) .
;		. /
public "
ErrorHandlerMiddleware %
(% &
RequestDelegate& 5
next6 :
): ;
{ 	
_next 
= 
next 
; 
} 	
public 
async 
Task 
Invoke  
(  !
HttpContext! ,
context- 4
)4 5
{ 	
try 
{ 
await 
_next 
( 
context #
)# $
;$ %
} 
catch 
( 
	Exception 
ex 
)  
{ 
var 
response 
= 
context &
.& '
Response' /
;/ 0
response 
. 
ContentType $
=% &
$str' 9
;9 :
HttpStatusCode 

statusCode )
=* +
ex, .
switch/ 5
{ 
NotFoundException %
=>& (
HttpStatusCode) 7
.7 8
NotFound8 @
,@ A
BusinessException %
=>& (
HttpStatusCode) 7
.7 8

BadRequest8 B
,B C
DatabaseException %
=>& (
HttpStatusCode) 7
.7 8
ServiceUnavailable8 J
,J K
_   
=>   
HttpStatusCode   '
.  ' (
InternalServerError  ( ;
}!! 
;!! 
var## 
result## 
=## 
JsonSerializer## +
.##+ ,
	Serialize##, 5
(##5 6
new##6 9
{$$ 

StatusCode%% 
=%%  
(%%! "
int%%" %
)%%% &

statusCode%%& 0
,%%0 1
Success&& 
=&& 
false&& #
,&&# $
Message'' 
='' 
ex''  
.''  !
Message''! (
}(( 
)(( 
;(( 
response** 
.** 

StatusCode** #
=**$ %
(**& '
int**' *
)*** +

statusCode**+ 5
;**5 6
await++ 
response++ 
.++ 

WriteAsync++ )
(++) *
result++* 0
)++0 1
;++1 2
},, 
}-- 	
}.. 
}// √9
cC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina\Filters\ApiResponseFilter.cs
	namespace 	
Nomina
 
. 
API 
. 
Filters 
{ 
public 

class 
ApiResponseFilter "
:# $
IActionFilter% 2
{		 
public

 
void

 
OnActionExecuting

 %
(

% &"
ActionExecutingContext

& <
context

= D
)

D E
{

F G
}

H I
public 
void 
OnActionExecuted $
($ %!
ActionExecutedContext% :
context; B
)B C
{ 	
if 
( 
! 
IsSuccessResponse "
(" #
context# *
.* +
Result+ 1
)1 2
)2 3
return 
; 
var 
objectResult 
= 
(  
ObjectResult  ,
), -
context- 4
.4 5
Result5 ;
!; <
;< =
if 
( 
objectResult 
. 
Value "
is# %
ApiResponse& 1
<1 2
object2 8
>8 9
)9 :
return 
; 
var 
( 
data 
, 
	totalRows  
)  !
=" ##
ExtractDataAndTotalRows$ ;
(; <
objectResult< H
.H I
ValueI N
)N O
;O P
var 
response 
= 
BuildResponse (
(( )

statusCode 
: 
objectResult (
.( )

StatusCode) 3
??4 6
$num7 :
,: ;
message 
: 
data 
is  
string! '

messageStr( 2
?3 4

messageStr5 ?
:@ A
$strB U
,U V
data 
: 
data 
, 
	totalRows 
: 
	totalRows $
) 
; 
context 
. 
Result 
= 
new  
ContentResult! .
{   

StatusCode!! 
=!! 
objectResult!! )
.!!) *

StatusCode!!* 4
,!!4 5
ContentType"" 
="" 
$str"" 0
,""0 1
Content## 
=## 
JsonSerializer## (
.##( )
	Serialize##) 2
(##2 3
response##3 ;
)##; <
}$$ 
;$$ 
}%% 	
private'' 
static'' 
bool'' 
IsSuccessResponse'' -
(''- .
object''. 4
?''4 5
result''6 <
)''< =
{(( 	
return)) 
result)) 
is)) 
ObjectResult)) )
obj))* -
&&)). 0
obj** 
.** 

StatusCode** !
is**" $
>=**% '
$num**( +
and**, /
<**0 1
$num**2 5
;**5 6
}++ 	
private-- 
static-- 
(-- 
object-- 
?-- 
Data--  $
,--$ %
int--& )
	TotalRows--* 3
)--3 4#
ExtractDataAndTotalRows--5 L
(--L M
object--M S
?--S T
value--U Z
)--Z [
{.. 	
if// 
(// 
value// 
is// 
null// 
or//  
string//! '
)//' (
return00 
(00 
value00 
,00 
$num00  
)00  !
;00! "
var22 
type22 
=22 
value22 
.22 
GetType22 $
(22$ %
)22% &
;22& '
var44 
	totalProp44 
=44 
type44  
.44  !
GetProperty44! ,
(44, -
$str44- 8
,448 9
System55 
.55 

Reflection55 !
.55! "
BindingFlags55" .
.55. /

IgnoreCase55/ 9
|55: ;
System66 
.66 

Reflection66 !
.66! "
BindingFlags66" .
.66. /
Public66/ 5
|666 7
System77 
.77 

Reflection77 !
.77! "
BindingFlags77" .
.77. /
Instance77/ 7
)777 8
;778 9
int99 
	totalRows99 
=99 
	totalProp99 %
?99% &
.99& '
GetValue99' /
(99/ 0
value990 5
)995 6
as997 9
int99: =
?99= >
??99? A
$num99B C
;99C D
var;; 
dataProp;; 
=;; 
type;; 
.;;  
GetProperty;;  +
(;;+ ,
$str;;, 2
,;;2 3
System<< 
.<< 

Reflection<< !
.<<! "
BindingFlags<<" .
.<<. /

IgnoreCase<</ 9
|<<: ;
System== 
.== 

Reflection== !
.==! "
BindingFlags==" .
.==. /
Public==/ 5
|==6 7
System>> 
.>> 

Reflection>> !
.>>! "
BindingFlags>>" .
.>>. /
Instance>>/ 7
)>>7 8
;>>8 9
var@@ 
data@@ 
=@@ 
dataProp@@ 
?@@  
.@@  !
GetValue@@! )
(@@) *
value@@* /
)@@/ 0
??@@1 3
value@@4 9
;@@9 :
returnBB 
(BB 
dataBB 
,BB 
	totalRowsBB #
)BB# $
;BB$ %
}CC 	
privateEE 
staticEE 

DictionaryEE !
<EE! "
stringEE" (
,EE( )
objectEE* 0
?EE0 1
>EE1 2
BuildResponseEE3 @
(EE@ A
intFF 

statusCodeFF 
,FF 
stringGG 
messageGG 
,GG 
objectHH 
?HH 
dataHH 
,HH 
intII 
	totalRowsII 
)II 
{JJ 	
varKK 
responseKK 
=KK 
newKK 

DictionaryKK )
<KK) *
stringKK* 0
,KK0 1
objectKK2 8
?KK8 9
>KK9 :
{LL 
[MM 
$strMM 
]MM 
=MM  

statusCodeMM! +
,MM+ ,
[NN 
$strNN 
]NN 
=NN 
trueNN "
,NN" #
[OO 
$strOO 
]OO 
=OO 
messageOO %
}PP 
;PP 
ifRR 
(RR 
dataRR 
isRR 
notRR 
nullRR  
andRR! $
notRR% (
stringRR) /
)RR/ 0
{SS 
responseTT 
[TT 
$strTT 
]TT  
=TT! "
dataTT# '
;TT' (
responseUU 
[UU 
$strUU $
]UU$ %
=UU& '
	totalRowsUU( 1
;UU1 2
}VV 
returnXX 
responseXX 
;XX 
}YY 	
}ZZ 
}[[ Í7
hC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina\Controllers\ReportesController.cs
	namespace

 	
Nomina


 
.

 
API

 
.

 
Controllers

  
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
ReportesController #
:$ %
ControllerBase& 4
{ 
private 
readonly !
IReporteNominaService .
_reporteService/ >
;> ?
public 
ReportesController !
(! "!
IReporteNominaService" 7
reporteService8 F
)F G
{ 	
_reporteService 
= 
reporteService ,
;, -
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
List% )
<) *
ReporteNominaView* ;
>; <
)< =
,= >
$num? B
)B C
]C D
public 
async 
Task 
< 
IActionResult '
>' ( 
GenerarReporteNomina) =
(= >
[ 
	FromQuery 
] 
string 
? 
PeriodoCodigo  -
,- .
[ 
	FromQuery 
] 
string 
? 
departamentoCodigo  2
,2 3
[ 
	FromQuery 
] 
string 
? 
cargoCodigo  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
tipoContratoCodigo  2
)2 3
{ 	
try   
{!! 
var"" 
reporte"" 
="" 
await"" #
_reporteService""$ 3
.""3 4
GenerarReporteAsync""4 G
(""G H
PeriodoCodigo## !
,##! "
departamentoCodigo$$ &
,$$& '
cargoCodigo%% 
,%%  
tipoContratoCodigo&& &
)'' 
;'' 
return)) 
Ok)) 
()) 
reporte)) !
)))! "
;))" #
}** 
catch++ 
(++ 
ArgumentException++ $
ex++% '
)++' (
{,, 
return-- 

BadRequest-- !
(--! "
new--" %
{--& '
success--( /
=--0 1
false--2 7
,--7 8
message--9 @
=--A B
ex--C E
.--E F
Message--F M
}--N O
)--O P
;--P Q
}.. 
catch// 
(// 
	Exception// 
ex// 
)//  
{00 
return11 

StatusCode11 !
(11! "
$num11" %
,11% &
new11' *
{11+ ,
success11- 4
=115 6
false117 <
,11< =
message11> E
=11F G
$"11H J
$str11J g
{11g h
ex11h j
.11j k
Message11k r
}11r s
"11s t
}11u v
)11v w
;11w x
}22 
}33 	
[55 	
HttpPost55	 
(55 
$str55 
)55 
]55  
[66 	 
ProducesResponseType66	 
(66 
typeof66 $
(66$ %

FileResult66% /
)66/ 0
,660 1
$num662 5
)665 6
]666 7
public77 
async77 
Task77 
<77 
IActionResult77 '
>77' (#
GenerarReporteNominaPdf77) @
(77@ A
[88 
FromBody88 
]88  
ReporteNominaRequest88 +
request88, 3
)883 4
{99 	
var:: 
PeriodoCodigo:: 
=:: 
request::  '
.::' (
PeriodoCodigo::( 5
;::5 6
var;; 
departamentoCodigo;; "
=;;# $
request;;% ,
.;;, -
DepartamentoCodigo;;- ?
;;;? @
var<< 
cargoCodigo<< 
=<< 
request<< %
.<<% &
CargoCodigo<<& 1
;<<1 2
var== 
tipoContratoCodigo== "
===# $
request==% ,
.==, -
TipoContratoCodigo==- ?
;==? @
if?? 
(?? 
!?? 

ModelState?? 
.?? 
IsValid?? #
)??# $
{@@ 
returnAA 

BadRequestAA !
(AA! "

ModelStateAA" ,
)AA, -
;AA- .
}BB 
tryDD 
{EE 
byteFF 
[FF 
]FF 
pdfBytesFF 
=FF  !
awaitFF" '
_reporteServiceFF( 7
.FF7 8"
GenerarReportePdfAsyncFF8 N
(FFN O
PeriodoCodigoGG !
,GG! "
departamentoCodigoHH &
,HH& '
cargoCodigoII 
,II  
tipoContratoCodigoJJ &
)KK 
;KK 
stringLL 
nombreArchivoLL $
=LL% &
$"LL' )
$strLL) 8
{LL8 9
DateTimeLL9 A
.LLA B
NowLLB E
:LLE F
$strLLF N
}LLN O
$strLLO S
"LLS T
;LLT U
returnNN 
FileNN 
(NN 
pdfBytesNN $
,NN$ %
$strNN& 7
,NN7 8
nombreArchivoNN9 F
)NNF G
;NNG H
}OO 
catchPP 
(PP 
ArgumentExceptionPP $
exPP% '
)PP' (
{QQ 
returnRR 

BadRequestRR !
(RR! "
newRR" %
{RR& '
successRR( /
=RR0 1
falseRR2 7
,RR7 8
messageRR9 @
=RRA B
exRRC E
.RRE F
MessageRRF M
}RRN O
)RRO P
;RRP Q
}SS 
catchTT 
(TT %
InvalidOperationExceptionTT ,
exTT- /
)TT/ 0
{UU 
returnVV 
NotFoundVV 
(VV  
newVV  #
{VV$ %
successVV& -
=VV. /
falseVV0 5
,VV5 6
messageVV7 >
=VV? @
exVVA C
.VVC D
MessageVVD K
}VVL M
)VVM N
;VVN O
}WW 
catchXX 
(XX 
	ExceptionXX 
exXX 
)XX  
{YY 
returnZZ 

StatusCodeZZ !
(ZZ! "
$numZZ" %
,ZZ% &
newZZ' *
{ZZ+ ,
successZZ- 4
=ZZ5 6
falseZZ7 <
,ZZ< =
messageZZ> E
=ZZF G
$"ZZH J
$strZZJ c
{ZZc d
exZZd f
.ZZf g
MessageZZg n
}ZZn o
"ZZo p
}ZZq r
)ZZr s
;ZZs t
}[[ 
}\\ 	
}]] 
}^^ ⁄(
fC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina\Controllers\NominaController.cs
	namespace 	
Nomina
 
. 
API 
. 
Controllers  
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class 
NominaController !
:" #
ControllerBase$ 2
{ 
private 
readonly 
INominaService '
_service( 0
;0 1
public 
NominaController 
(  
INominaService  .
service/ 6
)6 7
{ 	
_service 
= 
service 
; 
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
ProcesarNomina) 7
(7 8
[8 9
FromBody9 A
]A B
NominaFiltroRequestC V
requestW ^
)^ _
{ 	
var 
nominas 
= 
await 
_service  (
.( )
ProcesarNominaAsync) <
(< =
request= D
)D E
;E F
return 
Ok 
( 
nominas 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str  
)  !
]! "
public 
async 
Task 
< 
IActionResult '
>' (
ListarAnios) 4
(4 5
)5 6
{ 	
var 
anios 
= 
await 
_service &
.& '
ObtenerAniosAsync' 8
(8 9
)9 :
;: ;
return   
Ok   
(   
anios   
)   
;   
}!! 	
[## 	
HttpGet##	 
(## 
$str##  
)##  !
]##! "
public$$ 
async$$ 
Task$$ 
<$$ 
IActionResult$$ '
>$$' (
ListarMeses$$) 4
($$4 5
)$$5 6
{%% 	
var&& 
meses&& 
=&& 
await&& 
_service&& &
.&&& '
ObtenerMesesAsync&&' 8
(&&8 9
)&&9 :
;&&: ;
return'' 
Ok'' 
('' 
meses'' 
)'' 
;'' 
}(( 	
[++ 	
HttpGet++	 
(++ 
$str++ 
)++ 
]++ 
public,, 
async,, 
Task,, 
<,, 
IActionResult,, '
>,,' (
ListarDepartamentos,,) <
(,,< =
),,= >
{-- 	
var.. 
periodos.. 
=.. 
await..  
_service..! )
...) *
ObtenerPeriodoAsync..* =
(..= >
)..> ?
;..? @
return// 
Ok// 
(// 
periodos// 
)// 
;//  
}00 	
[22 	
HttpGet22	 
(22 
$str22 
)22 
]22 
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' (
ListarContratos33) 8
(338 9
)339 :
{44 	
var55 
	empleados55 
=55 
await55 !
_service55" *
.55* + 
ObtenerContratoAsync55+ ?
(55? @
)55@ A
;55A B
return66 
Ok66 
(66 
	empleados66 
)66  
;66  !
}77 	
[99 	
HttpGet99	 
(99 
$str99  
)99  !
]99! "
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
ListarPeriodos::) 7
(::7 8
)::8 9
{;; 	
var<< 
departamentos<< 
=<< 
await<<  %
_service<<& .
.<<. /%
ObtenerDepartamentosAsync<</ H
(<<H I
)<<I J
;<<J K
return== 
Ok== 
(== 
departamentos== #
)==# $
;==$ %
}>> 	
[@@ 	
HttpPost@@	 
(@@ 
$str@@ 
)@@ 
]@@ 
publicAA 
asyncAA 
TaskAA 
<AA 
IActionResultAA '
>AA' (
CrearNominaAA) 4
(AA4 5
[AA5 6
FromBodyAA6 >
]AA> ?
NominaRequestAA@ M
requestAAN U
)AAU V
{BB 	
awaitCC 
_serviceCC 
.CC 
CrearNominaAsyncCC +
(CC+ ,
requestCC, 3
)CC3 4
;CC4 5
returnDD 
OkDD 
(DD 
$strDD =
)DD= >
;DD> ?
}EE 	
}GG 
}HH µO
rC:\Users\ACER NITRO 5\Desktop\Calidad de Software\NominaBackend\Nomina\Controllers\ContratosLaboralesController.cs
	namespace 	
Nomina
 
. 
API 
. 
Controllers  
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str 
) 
] 
public 

class %
ContratoLaboralController *
:+ ,
ControllerBase- ;
{ 
private 
readonly #
IContratoLaboralService 0
_contratoService1 A
;A B
public %
ContratoLaboralController (
(( )#
IContratoLaboralService) @
contratoServiceA P
)P Q
{ 	
_contratoService 
= 
contratoService .
;. /
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
GetContratos) 5
(5 6
)6 7
{ 	
var 
	contratos 
= 
await !
_contratoService" 2
.2 3
ConsultarContratos3 E
(E F
)F G
;G H
return 
Ok 
( 
	contratos 
)  
;  !
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
	Registrar) 2
(2 3
[3 4
FromBody4 <
]< =
RegistroContratoDto> Q
requestR Y
)Y Z
{ 	
var 
	resultado 
= 
await !
_contratoService" 2
.2 3
RegistrarContrato3 D
(D E
requestE L
)L M
;M N
return 
Ok 
( 
	resultado 
)  
;  !
} 	
[   	
HttpPut  	 
(   
$str   
)   
]   
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
PutContrato!!) 4
(!!4 5
string!!5 ;
contratoCodigo!!< J
,!!J K
[!!L M
FromBody!!M U
]!!U V
ContratoLaboralDto!!W i
dto!!j m
)!!m n
{"" 	
if## 
(## 
dto## 
==## 
null## 
||## 
string## %
.##% &
IsNullOrWhiteSpace##& 8
(##8 9
contratoCodigo##9 G
)##G H
)##H I
return$$ 

BadRequest$$ !
($$! "
$str$$" 4
)$$4 5
;$$5 6
try&& 
{'' 
dto(( 
.(( 
ContratoCodigo(( "
=((# $
contratoCodigo((% 3
;((3 4
await)) 
_contratoService)) &
.))& '
ModificarContrato))' 8
())8 9
dto))9 <
)))< =
;))= >
return** 
Ok** 
(** 
$str** >
)**> ?
;**? @
}++ 
catch,, 
(,, 
	Exception,, 
ex,, 
),,  
{-- 
return.. 

BadRequest.. !
(..! "
new.." %
{..& '
error..( -
=... /
ex..0 2
...2 3
Message..3 :
}..; <
)..< =
;..= >
}// 
}00 	
[11 	

HttpDelete11	 
(11 
$str11 
)11 
]11  
public22 
async22 
Task22 
<22 
IActionResult22 '
>22' (
DeleteContrato22) 7
(227 8
string228 >
contratoCodigo22? M
)22M N
{33 	
if44 
(44 
string44 
.44 
IsNullOrWhiteSpace44 )
(44) *
contratoCodigo44* 8
)448 9
)449 :
return55 

BadRequest55 !
(55! "
$str55" @
)55@ A
;55A B
try77 
{88 
await99 
_contratoService99 &
.99& '
EliminarContrato99' 7
(997 8
contratoCodigo998 F
)99F G
;99G H
return:: 
Ok:: 
(:: 
$str:: =
)::= >
;::> ?
};; 
catch<< 
(<< 
	Exception<< 
ex<< 
)<<  
{== 
return>> 

BadRequest>> !
(>>! "
new>>" %
{>>& '
error>>( -
=>>. /
ex>>0 2
.>>2 3
Message>>3 :
}>>; <
)>>< =
;>>= >
}?? 
}@@ 	
[AA 	
HttpGetAA	 
(AA 
$strAA 
)AA  
]AA  !
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
ListadoPorTipoBB) 7
(BB7 8
)BB8 9
{CC 	
varDD 
dataDD 
=DD 
awaitDD 
_contratoServiceDD -
.DD- ."
ListarContratosPorTipoDD. D
(DDD E
)DDE F
;DDF G
returnEE 
OkEE 
(EE 
dataEE 
)EE 
;EE 
}FF 	
[HH 	
HttpGetHH	 
(HH 
$strHH 
)HH 
]HH 
publicII 
asyncII 
TaskII 
<II 
IActionResultII '
>II' (
ListadoPorModalidadII) <
(II< =
)II= >
{JJ 	
varKK 
dataKK 
=KK 
awaitKK 
_contratoServiceKK -
.KK- .'
ListarContratosPorModalidadKK. I
(KKI J
)KKJ K
;KKK L
returnLL 
OkLL 
(LL 
dataLL 
)LL 
;LL 
}MM 	
[OO 	
HttpGetOO	 
(OO 
$strOO 
)OO 
]OO 
publicPP 
asyncPP 
TaskPP 
<PP 
IActionResultPP '
>PP' (
ListadoPorJornadaPP) :
(PP: ;
)PP; <
{QQ 	
varRR 
dataRR 
=RR 
awaitRR 
_contratoServiceRR -
.RR- .%
ListarContratosPorJornadaRR. G
(RRG H
)RRH I
;RRI J
returnSS 
OkSS 
(SS 
dataSS 
)SS 
;SS 
}TT 	
[VV 	
HttpGetVV	 
(VV 
$strVV 
)VV 
]VV 
publicWW 
asyncWW 
TaskWW 
<WW 
IActionResultWW '
>WW' (
ListadoPorEstadoWW) 9
(WW9 :
)WW: ;
{XX 	
varYY 
dataYY 
=YY 
awaitYY 
_contratoServiceYY -
.YY- .$
ListarContratosPorEstadoYY. F
(YYF G
)YYG H
;YYH I
returnZZ 
OkZZ 
(ZZ 
dataZZ 
)ZZ 
;ZZ 
}[[ 	
[\\ 	
HttpGet\\	 
(\\ 
$str\\ $
)\\$ %
]\\% &
public]] 
async]] 
Task]] 
<]] 
IActionResult]] '
>]]' ( 
GetHistorialDetalles]]) =
(]]= >
)]]> ?
{^^ 	
var__ 
result__ 
=__ 
await__ 
_contratoService__ /
.__/ 0#
ListarHistorialDetalles__0 G
(__G H
)__H I
;__I J
return`` 
Ok`` 
(`` 
result`` 
)`` 
;`` 
}aa 	
[bb 	
HttpGetbb	 
(bb 
$strbb '
)bb' (
]bb( )
publiccc 
asynccc 
Taskcc 
<cc 
IActionResultcc '
>cc' (#
GetEmpleadosSinContratocc) @
(cc@ A
)ccA B
{dd 	
varee 
resultee 
=ee 
awaitee 
_contratoServiceee /
.ee/ 0&
ListarEmpleadosSinContratoee0 J
(eeJ K
)eeK L
;eeL M
returnff 
Okff 
(ff 
resultff 
)ff 
;ff 
}gg 	
[hh 	
HttpPuthh	 
(hh 
$strhh  
)hh  !
]hh! "
publicii 
asyncii 
Taskii 
<ii 
IActionResultii '
>ii' (!
CambiarEstadoContratoii) >
(ii> ?
stringii? E
codigoiiF L
,iiL M
[iiN O
	FromQueryiiO X
]iiX Y
stringiiZ `
nuevoEstadoiia l
,iil m
[iin o
	FromQueryiio x
]iix y
string	iiz Ä
motivo
iiÅ á
)
iiá à
{jj 	
ifkk 
(kk 
stringkk 
.kk 
IsNullOrWhiteSpacekk )
(kk) *
motivokk* 0
)kk0 1
)kk1 2
returnll 

BadRequestll !
(ll! "
$strll" W
)llW X
;llX Y
awaitnn 
_contratoServicenn "
.nn" #
SuspenderContratonn# 4
(nn4 5
codigonn5 ;
,nn; <
nuevoEstadonn= H
,nnH I
motivonnJ P
)nnP Q
;nnQ R
returnoo 
Okoo 
(oo 
newoo 
{oo 
mensajeoo #
=oo$ %
$"oo& (
$stroo( 1
{oo1 2
codigooo2 8
}oo8 9
$stroo9 O
{ooO P
nuevoEstadoooP [
}oo[ \
"oo\ ]
}oo^ _
)oo_ `
;oo` a
}pp 	
}qq 
}rr 