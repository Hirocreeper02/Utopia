from unit import *

class Battlefield():
    
    class BattleMember():
        
        def __init__(self,tactics:str):
            """
            Serves as a mean of storing informations of the camps in the battle
            """
            
            self.tactics = tactics
    
    def __init__(self, spawn_information:list = [None for _ in range(36)]):
        """
            spawn_information (len = 36):
                 0,1  |  2,3  |  4,5  \n
                 6,7  |  8,9  | 10,11 \n
                12,13 | 14,15 | 16,17 \n
                ----------------------\n
                ######################\n
                ----------------------\n
                18,19 | 20,21 | 22,23 \n
                24,25 | 26,27 | 28,29 \n
                30,31 | 32,33 | 34,35 \n
            
            terrain (len = 3):
                [left,mid,right]
        
        """
        self.terrain = [
            [ # Row 1
                [ # Column 1
                    { # Inside cells
                        "Long range" : [
                            spawn_information[0],
                            spawn_information[1]
                        ],
                        "Medium range" : [
                            spawn_information[6],
                            spawn_information[7]
                        ],
                        "Short range" : [
                            spawn_information[12],
                            spawn_information[13]
                        ]
                    }
                ],
                [ # Column 2
                    { # Inside cells
                        "Long range" : [
                            spawn_information[2],
                            spawn_information[3]
                        ],
                        "Medium range" : [
                            spawn_information[8],
                            spawn_information[9]
                        ],
                        "Short range" : [
                            spawn_information[14],
                            spawn_information[15]
                        ]
                    }
                ],
                [ # Column 3
                    { # Inside cells
                        "Long range" : [
                            spawn_information[4],
                            spawn_information[5]
                        ],
                        "Medium range" : [
                            spawn_information[10],
                            spawn_information[11]
                        ],
                        "Short range" : [
                            spawn_information[16],
                            spawn_information[17]
                        ]
                    }
                ]
            ],
            [ # Row 2
                "Plain",
                "Plain",
                "Plain"
            ],
            [ # Row 3
                [ # Column 1
                    { # Inside cells
                        "Short range" : [
                            spawn_information[18],
                            spawn_information[19]
                        ],
                        "Medium range" : [
                            spawn_information[24],
                            spawn_information[25]
                        ],
                        "Long range" : [
                            spawn_information[30],
                            spawn_information[31]
                        ]
                    }
                ],
                [ # Column 2
                    { # Inside cells
                        "Short range" : [
                            spawn_information[20],
                            spawn_information[21]
                        ],
                        "Medium range" : [
                            spawn_information[26],
                            spawn_information[27]
                        ],
                        "Long range" : [
                            spawn_information[32],
                            spawn_information[33]
                        ]
                    }
                ],
                [ # Column 3
                    { # Inside cells
                        "Short range" : [
                            spawn_information[22],
                            spawn_information[23]
                        ],
                        "Medium range" : [
                            spawn_information[28],
                            spawn_information[29]
                        ],
                        "Long range" : [
                            spawn_information[34],
                            spawn_information[35]
                        ]
                    }
                ]
            ],
        ]
    
    def attack_lane(attackers_side:int, lane:int, stratagem:list):
        pass
    
    
    
    def _listify_terrain(self) -> list:
        """
            Returns the terrain as a list of rows of units
        """
        
        output_list = []
        keys_list = ["Long range","Medium range","Short range"]
        
        for iteration in range(2):
            
            if iteration == 1:
                
                keys_list.reverse()
            
            for i,key in enumerate(keys_list):
                
                output_list.append([])
                
                for row in self.terrain[iteration*2]:
                    
                    for column in row:
                        
                        output_list[i+(iteration*3)].append(column[key][0])
                        output_list[i+(iteration*3)].append(column[key][1])
        
        return output_list
    
    
    def __str__(self):
        
        representation = self._listify_terrain()
        
        
        
        for i in range(len(representation)):
            
            #representation[i] = list(map(str,representation[i]))
            
            for j in range(len(representation[i])):
                
                if representation[i][j] == None:
                    
                    representation[i][j] = "   "
                else:
                    
                    representation[i][j] = representation[i][j].tag
                
                representation[i][j] = " " + representation[i][j]
            
            representation[i].insert(2," |")
            representation[i].insert(5," |")
            representation[i].append("\n")
        
        representation.insert(3,["#####" for _ in range(6)])
        representation[3][-1] = "####\n"
        
        
        return "".join(["".join(line) for line in representation])
    
    def __getitem__(self,index:tuple):
        
        match len(index):
            
            case 0:
                return self.terrain
            
            case 1:
                return self.terrain[index[0]]
            
            case 2:
                return self.terrain[index[0]][index[1]]
            
            case 3:
                return self.terrain[index[0]][index[1]][index[2]]
            
            case 4:
                return self.terrain[index[0]][index[1]][index[2]][index[3]]
            
            case 5:
                return self.terrain[index[0]][index[1]][index[2]][index[3]][index[4]]
            
            case _:
                print("Unexisting call")
                return False
    
    def __setitem__(self,index:tuple,value):
        
        match len(index):
            
            case 0:
                self.terrain = value
            
            case 1:
                self.terrain[index[0]] = value
            
            case 2:
                self.terrain[index[0]][index[1]] = value
            
            case 3:
                self.terrain[index[0]][index[1]][index[2]] = value
            
            case 4:
                self.terrain[index[0]][index[1]][index[2]][index[3]] = value
            
            case 5:
                self.terrain[index[0]][index[1]][index[2]][index[3]][index[4]] = value
            
            case _:
                print("Unexisting call")
                return False


my_battlefield = Battlefield(spawn_information = [knight for _ in range(36)])
my_battlefield[0,0,0,"Long range"] = [knight,None]

print(my_battlefield)

print(my_battlefield[0,0])
