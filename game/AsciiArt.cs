using System;

namespace AsciiArt
{

  public class Line
  {
    public string LineArt()
    {
      return "\n----------------------------------------------------------------------\n";
    }
  }
  public class Title
  {
    public string TitleArt()
    {
      return @"

▄▄▄█████▓██░ ██ ██▀███  ▒█████  █    ██  ▄████ ██░ ██     ███▄ ▄███▓█    ██▓█████▄     ▄▄▄      ███▄    █▓█████▄     ▄▄▄▄   ██▓    ▒█████  ▒█████ ▓█████▄
▓  ██▒ ▓▓██░ ██▓██ ▒ ██▒██▒  ██▒██  ▓██▒██▒ ▀█▓██░ ██▒   ▓██▒▀█▀ ██▒██  ▓██▒██▀ ██▌   ▒████▄    ██ ▀█   █▒██▀ ██▌   ▓█████▄▓██▒   ▒██▒  ██▒██▒  ██▒██▀ ██▌
▒ ▓██░ ▒▒██▀▀██▓██ ░▄█ ▒██░  ██▓██  ▒██▒██░▄▄▄▒██▀▀██░   ▓██    ▓██▓██  ▒██░██   █▌   ▒██  ▀█▄ ▓██  ▀█ ██░██   █▌   ▒██▒ ▄█▒██░   ▒██░  ██▒██░  ██░██   █▌
░ ▓██▓ ░░▓█ ░██▒██▀▀█▄ ▒██   ██▓▓█  ░██░▓█  ██░▓█ ░██    ▒██    ▒██▓▓█  ░██░▓█▄   ▌   ░██▄▄▄▄██▓██▒  ▐▌██░▓█▄   ▌   ▒██░█▀ ▒██░   ▒██   ██▒██   ██░▓█▄   ▌
  ▒██▒ ░░▓█▒░██░██▓ ▒██░ ████▓▒▒▒█████▓░▒▓███▀░▓█▒░██▓   ▒██▒   ░██▒▒█████▓░▒████▓     ▓█   ▓██▒██░   ▓██░▒████▓    ░▓█  ▀█░██████░ ████▓▒░ ████▓▒░▒████▓
  ▒ ░░   ▒ ░░▒░░ ▒▓ ░▒▓░ ▒░▒░▒░░▒▓▒ ▒ ▒ ░▒   ▒ ▒ ░░▒░▒   ░ ▒░   ░  ░▒▓▒ ▒ ▒ ▒▒▓  ▒     ▒▒   ▓▒█░ ▒░   ▒ ▒ ▒▒▓  ▒    ░▒▓███▀░ ▒░▓  ░ ▒░▒░▒░░ ▒░▒░▒░ ▒▒▓  ▒
    ░    ▒ ░▒░ ░ ░▒ ░ ▒░ ░ ▒ ▒░░░▒░ ░ ░  ░   ░ ▒ ░▒░ ░   ░  ░      ░░▒░ ░ ░ ░ ▒  ▒      ▒   ▒▒ ░ ░░   ░ ▒░░ ▒  ▒    ▒░▒   ░░ ░ ▒  ░ ░ ▒ ▒░  ░ ▒ ▒░ ░ ▒  ▒
  ░      ░  ░░ ░ ░░   ░░ ░ ░ ▒  ░░░ ░ ░░ ░   ░ ░  ░░ ░   ░      ░   ░░░ ░ ░ ░ ░  ░      ░   ▒     ░   ░ ░ ░ ░  ░     ░    ░  ░ ░  ░ ░ ░ ▒ ░ ░ ░ ▒  ░ ░  ░
         ░  ░  ░  ░        ░ ░    ░          ░ ░  ░  ░          ░     ░       ░             ░  ░        ░   ░        ░         ░  ░   ░ ░     ░ ░    ░    
";
    }
  }
  public class Death
  {
    public string SkullArt()
    {
      return @"
                           ,--.
                          {....}
                          K,.. }
                         /  `Y`
                    _   /   /
                   {_'-K.__/
                     `/-.__L._
                     /  ' /`\_}
                    /  ' /
            ____   /  ' /
     ,-'~~~~ %% ~~/  ' /_
   ,'         %%%%``~~~%%',
  (            %%   %  %  Y
 {            %     %   %% I
{      -      %    %     %  |
|      '',                %  )
|      ''|   ,..__      __. Y
|    .,_./  Y ' / ^Y   J'/ )|
\           |' /   |   |   ||
 \      '   L /    . _ (_,.'(
  \,_   ,      ^^""' / |     )
      \             /,L]    /
      '-_`-,       ` `    ./
    ..,,  `-(_ .          )
.....,,,,,,, ^^\_[]]]]]]]} ......
       .......,,,,,,,.,,,..,..
        ";

    }
  }

  public class Win
  {
    public string Winart()
    {
      return @"                                                                              
                                           --=--            
                                          .**###.           
                                          ++*%#%=...        
                                       :--###%##%####-      
                                     .*#+**###*%%**###+     
                                     *##*+*##*#%%%%@#*#-    
                                     +##++**##*#%%+@@+#+    
                                     -%#++***####+ =%##*    
                                     *#%++*#***##. :*###:   
                                     #%%*+%#*##%#- .###*.   
                                    -%##*%@@%**#%=  ***:    
                                -=+@##%#%@@%%@#### -%#*     
                          .:--=--+##%+%%%%%@%%%@%#.%%#-     
                    .:--==--=---::-. :%%%%%%%%%%%% .=:      
              .:-===--=--::.         =%@%%%%%%%%%%:         
        .:--==--=---:.               :####%+-+%#*#.         
     -===-=--::.                      -+###= *##**=         
    ----:.                             +##%= +%%**:         
                                       +###   #%##          
                                       +#%*   =%##          
                                       +*#*   :%**          
                                       *#%*   :#*#=         
                                      +*##%    ***#-        
                                   .+*+++=#     ####:.            
     
";
    }
  }
  public class Places
  {
    public string Yuandao()
    {
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      return @"
        
               )\         O_._._._A_._._._O         /(
                \`--.___,'=================`.___,--'/
                 \`--._.__                 __._,--'/
                   \  ,. l`~~~~~~~~~~~~~~~'l ,.  /
       __            \||(_)!_!_!_.-._!_!_!(_)||/            __
       \\`-.__        ||_|____!!_|;|_!!____|_||        __,-'//
        \\    `==---='-----------'='-----------`=---=='    //
        | `--.                                         ,--' |
         \  ,.`~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~',.  /
           \||  ____,-------._,-------._,-------.____  ||/
            ||\|___!`======= !`======= !`======= !___|/||
            || |---||--------||-| | |-!!--------||---| ||
  __O_____O_ll_lO_____O_____O|| |'|'| ||O_____O_____Ol_ll_O_____O__
  o H o o H o o H o o H o o |-----------| o o H o o H o o H o o H o
 ___H_____H_____H_____H____O =========== O____H_____H_____H_____H___
                          /|=============|\
()______()______()______() '==== +-+ ====' ()______()______()______()
||{_}{_}||{_}{_}||{_}{_}/| ===== |_| ===== |\{_}{_}||{_}{_}||{_}{_}||
||      ||      ||     / |==== s(   )s ====| \     ||      ||      ||
======================()  =================  ()======================
----------------------/| ------------------- |\----------------------
                     / |---------------------| \
-'--'--'           ()  '---------------------'  ()
                   /| ------------------------- |\    --'--'--'
       --'--'     / |---------------------------| \    '--'
                ()  |___________________________|  ()           '--'-
  --'-          /| _______________________________  |\
 --'           / |__________________________________| \

        ";
    }
    public string Jettaiah()
    {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      return @"
                                  .-.
                                 /___\
                                 |___|
                                 |]_[|
                                 / I \
                              JL/  |  \JL
   .-.                    i   ()   |   ()   i                    .-.
   |_|     .^.           /_\  LJ=======LJ  /_\           .^.     |_|
._/___\._./___\_._._._._.L_J_/.-.     .-.\_L_J._._._._._/___\._./___\._._._
       ., |-,-| .,       L_J  |_| [I] |_|  L_J       ., |-,-| .,        .,
       JL |-O-| JL       L_J%%%%%%%%%%%%%%%L_J       JL |-O-| JL        JL
IIIIII_HH_'-'-'_HH_IIIIII|_|=======H=======|_|IIIIII_HH_'-'-'_HH_IIIIII_HH
-------[]-------[]-------[_]----\.=I=./----[_]-------[]-------[]--------[]-
 _/\_  ||\\_I_//||  _/\_ [_] []_/_L_J_\_[] [_] _/\_  ||\\_I_//||  _/\_  ||\
 |__|  ||=/_|_\=||  |__|_|_|   _L_L_J_J_   |_|_|__|  ||=/_|_\=||  |__|  ||-
 |__|  |||__|__|||  |__[___]__--__===__--__[___]__|  |||__|__|||  |__|  |||
IIIIIII[_]IIIII[_]IIIIIL___J__II__|_|__II__L___JIIIII[_]IIIII[_]IIIIIIII[_]
 \_I_/ [_]\_I_/[_] \_I_[_]\II/[]\_\I/_/[]\II/[_]\_I_/ [_]\_I_/[_] \_I_/ [_]
./   \.L_J/   \L_J./   L_JI  I[]/     \[]I  IL_J    \.L_J/   \L_J./   \.L_J
|     |L_J|   |L_J|    L_J|  |[]|     |[]|  |L_J     |L_J|   |L_J|     |L_J
      ";
    }
    public string Victornia()
    {
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      return @"                          
                                             /j\                              
                                           ,/:/#\                /\           
                                         ,//' '/#\              //#\          
                                        /' :   '/#\            /  /#\         
                                    ,  /' /'    '/#\          /    /#\   
                                   /'\'-._:__    '/#\        ;      /#,
                                  / ;#\']. ; ...--./#J       ':____...!       
                                 /   /#\  J  [;[;[;Y]         |      ;        
                                /    '/#\ ;   . .  |     !    |   #! |        
                               /      ,/#\'-..____.;_,   |    |   '  |        
                               :_....___,/#} .####. | '_.-.,   | #['  |        
                                |[;[;[;[;|         |.;'  /;\  |      |        
                                |        :     _   .;'    /;\ |   #. |        
                                :      _  ;   ##' .;'      /;\|  _,  |        
                     .#\...---..._    ';, |      .;{___     /;\  ]#' |
          .--.      ;'/#\         \    ]! |       .| , ...--./_J    /         
         /  '%;    /  '/#\         \   !' :        |!# #! #! #|    :  
        i__..'%] _:_   ;##J         \      :.#...._!   '  .  .|__  |   
         | .--... !|....  |...----...J     | '##.. `-._       |  ...---.._  
     ____: |      #|      |         #|     |          .]      ;   ___...-.T,  
    /   :  :      !|      |   _______!_    |           |__..--;...     ,;MM;  
   :____| :    .-.#|      |  /\      /#\   |          /'               ''MM;  
    |...: |   /   \|   .----+  ;      /#\  :___..--..;                  ,'MM; 
   _Y--:  |  ;     ;.-'      ;  \______/#: /         ;                  ''MM; 
  /    |  | ;_______;     ____!  |.##...MM!         ;                    ,'MM;
 !_____|  |  |.#.#.|____.'..##.  |       :         ;                     ''MM  
  | ....--!._|     |##..         !       !         :____.....-------...... |'
  |          :     |______                        ___!_ .#..#..#...#...#...|  
__|          ;     |MM.MM.....---..._______...--..MM.MM]                   |   
  .\-.      :      |#                                  :                   |  
    /#'.    |      /##,                                !                   |  
   .',/'\   |       #:#,                                ;       .==.       |  
  /.\'#.\',.|       ##;#,                               !     ,'||||',     |  
        /;/`:       ######,          ____             _ :     M||||||M     |  
       ###          /;.\.__.-._   ...                   |===..M!!!!!!M_____|   
      ";
    }
  }
}