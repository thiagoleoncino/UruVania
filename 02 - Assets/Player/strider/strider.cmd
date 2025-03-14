
[Remap]
x = x
y = y
z = z
a = a
b = b
c = c
s = s

;-| Default Values |-------------------------------------------------------
[Defaults]
; Default value for the "time" parameter of a Command. Minimum 1.
command.time = 15

; Default value for the "buffer.time" parameter of a Command. Minimum 1,
; maximum 30.
command.buffer.time = 1

[Command]
name = "SwitchWalls"
command = ~B, F
time = 10


[Command]
name = "FallOff"
command = F

;-| special motions |--------------------------------------------------------
[command]
name = "charge_x"
command = ~40$B,F,x
time = 15
command.buffer.time = 10

[command]
name = "charge_y"
command = ~40$B,F,y
time = 15
command.buffer.time = 10

[command]
name = "charge_z"
command = ~40$B,F,z
time = 15
command.buffer.time = 10

[command]
name = "vcharge_x"
command = ~40$D,U,x
time = 15
command.buffer.time = 10

[command]
name = "vcharge_y"
command = ~40$D,U,y
time = 15

[command]
name = "vcharge_z"
command = ~40$D,U,z
time = 15
command.buffer.time = 10

[command]
name = "vcharge_a"
command = ~40$D,U,a
time = 15
command.buffer.time = 10

[command]
name = "vcharge_b"
command = ~40$D,U,b
time = 15
command.buffer.time = 10

[command]
name = "vcharge_c"
command = ~40$D,U,c
time = 15
command.buffer.time = 10

[command]
name = "charge_a"
command = ~40$B,F,a
time = 15
command.buffer.time = 10

[command]
name = "charge_b"
command = ~40$B,F,b
time = 15
command.buffer.time = 10

[command]
name = "charge_c"
command = ~40$B,F,c
time = 15
command.buffer.time = 10

[command]
name = "DUa"
command = $D,U,a
time = 15
command.buffer.time = 10

[command]
name = "DUb"
command = $D,U,b
time = 15
command.buffer.time = 10

[command]
name = "DUc"
command = $D,U,c
time = 15
command.buffer.time = 10

[command]
name = "hold x"
command = /$x
time = 1

[command]
name = "hold y"
command = /$y
time = 1

[command]
name = "hold z"
command = /$z
time = 1

[command]
name = "hold a"
command = /$a
time = 1

[command]
name = "hold b"
command = /$b
time = 1

[command]
name = "hold c"
command = /$c
time = 1

;=========================================================
[command]
name = "rdp_x"
command = ~B, D, DB, x
command.buffer.time = 10

[command]
name = "rdp_y"
command = ~B, D, DB, y
command.buffer.time = 10

[command]
name = "rdp_z"
command = ~B, D, DB, z
command.buffer.time = 10

[command]
name = "rdp_a"
command = ~B, D, DB, a
command.buffer.time = 10

[command]
name = "rdp_b"
command = ~B, D, DB, b
command.buffer.time = 10

[command]
name = "rdp_c"
command = ~B, D, DB, c
command.buffer.time = 10

[command]
name = "dp_x"
command = ~F, D, DF, x
command.buffer.time = 10

[command]
name = "dp_y"
command = ~F, D, DF, y
command.buffer.time = 10

[command]
name = "dp_z"
command = ~F, D, DF, z
command.buffer.time = 10

[command]
name = "dp_a"
command = ~F, D, DF, a
command.buffer.time = 10

[command]
name = "dp_b"
command = ~F, D, DF, b
command.buffer.time = 10

[command]
name = "dp_c"
command = ~F, D, DF, c
command.buffer.time = 10
;=========================================
;simple
;=========================================================
[command]
name = "rdp_x"
command = ~B, D, B, x
command.buffer.time = 10

[command]
name = "rdp_y"
command = ~B, D, B, y
command.buffer.time = 10

[command]
name = "rdp_z"
command = ~B, D, B, z
command.buffer.time = 10

[command]
name = "rdp_a"
command = ~B, D, B, a
command.buffer.time = 10

[command]
name = "rdp_b"
command = ~B, D, B, b
command.buffer.time = 10

[command]
name = "rdp_c"
command = ~B, D, B, c
command.buffer.time = 10

[command]
name = "dp_x"
command = ~F, D, F, x
command.buffer.time = 10

[command]
name = "dp_y"
command = ~F, D, F, y
command.buffer.time = 10

[command]
name = "dp_z"
command = ~F, D, F, z
command.buffer.time = 10

[command]
name = "dp_a"
command = ~F, D, F, a
command.buffer.time = 10

[command]
name = "dp_b"
command = ~F, D, F, b
command.buffer.time = 10

[command]
name = "dp_c"
command = ~F, D, F, c
command.buffer.time = 10
;=========================================

[command]
name = "hcb_x"
command = ~F, D, B, x
time = 30
command.buffer.time = 10

[command]
name = "hcb_y"
command = ~F, D, B, y
time = 30
command.buffer.time = 10

[command]
name = "hcb_z"
command = ~F, D, B, z
time = 30
command.buffer.time = 10

[command]
name = "hcb_a"
command = ~F, D, B, a
time = 40
command.buffer.time = 10

[command]
name = "hcb_b"
command = ~F, D, B, b
time = 40
command.buffer.time = 10

[command]
name = "hcb_c"
command = ~F, D, B, c
time = 40
command.buffer.time = 10

[command]
name = "qcb_x"
command = ~D, DB, B,x
command.buffer.time = 10

[command]
name = "qcb_y"
command = ~D, DB, B,y
command.buffer.time = 10

[command]
name = "qcb_z"
command = ~D, DB, B,z
command.buffer.time = 10

[command]
name = "qcb_a"
command = ~D, DB, B,a
command.buffer.time = 10

[command]
name = "qcb_b"
command = ~D, DB, B,b
command.buffer.time = 10

[command]
name = "qcb_c"
command = ~D, DB, B,c
command.buffer.time = 10

[command]
name = "qcf_x"
command = ~D, DF, F,x
command.buffer.time = 10

[command]
name = "qcf_y"
command = ~D, DF, F,y
command.buffer.time = 10

[command]
name = "qcf_z"
command = ~D, DF, F,z
command.buffer.time = 10

[command]
name = "qcf_a"
command = ~D, DF, F,a
command.buffer.time = 10

[command]
name = "qcf_b"
command = ~D, DF, F,b
command.buffer.time = 10

[command]
name = "qcf_c"
command = ~D, DF, F,c
command.buffer.time = 10

;360--------------------------------------------------------------------------------
[Command]
name = "360_x"
command = ~F, D, B, /$U, x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~D, B, U, /$F, x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~B, U, F, /$D, x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~U, F, D, /$B, x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~F, U, B, /$D, x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~D, F, U, /$B, x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~B, D, F, /$U, x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~U, B, D, /$F, x
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~F, D, B, /$U, y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~D, B, U, /$F, y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~B, U, F, /$D, y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~U, F, D, /$B, y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~F, U, B, /$D, y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~D, F, U, /$B, y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~B, D, F, /$U, y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~U, B, D, /$F, y
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~F, D, B, /$U, z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~D, B, U, /$F, z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~B, U, F, /$D, z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~U, F, D, /$B, z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~F, U, B, /$D, z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~D, F, U, /$B, z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~B, D, F, /$U, z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~U, B, D, /$F, z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, D, B, /$U, x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, B, U, /$F, x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, U, F, /$D, x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, F, D, /$B, x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, U, B, /$D, x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, F, U, /$B, x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, D, F, /$U, x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, B, D, /$F, x+y
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, D, B, /$U, y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, B, U, /$F, y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, U, F, /$D, y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, F, D, /$B, y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, U, B, /$D, y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, F, U, /$B, y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, D, F, /$U, y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, B, D, /$F, y+z
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, D, B, /$U, x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, B, U, /$F, x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, U, F, /$D, x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, F, D, /$B, x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, U, B, /$D, x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, F, U, /$B, x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, D, F, /$U, x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, B, D, /$F, x+z
command.buffer.time = 10

;super motions----------------------------------------------------------------------

;=======================================================
[command]
name = "rdp_xy"
command = ~B, D, DB, x+y
command.buffer.time = 10

[command]
name = "rdp_xy"
command = ~B, D, DB, x+z
command.buffer.time = 10

[command]
name = "rdp_xy"
command = ~B, D, DB, y+z
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, DB, a+b
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, DB, a+c
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, DB, b+c
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, DF, x+y
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, DF, x+z
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, DF, y+z
command.buffer.time = 10

[command]
name = "dp_ab"
command = ~F, D, DF, a+b
command.buffer.time = 10

[command]
name = "dp_ab"
command = ~F, D, DF, a+c
command.buffer.time = 10

[command]
name = "dp_ab"
command = ~F, D, DF, b+c
command.buffer.time = 10
;========================================================
;simple
;=======================================================
[command]
name = "rdp_xy"
command = ~B, D, B, x+y
command.buffer.time = 10

[command]
name = "rdp_xy"
command = ~B, D, B, x+z
command.buffer.time = 10

[command]
name = "rdp_xy"
command = ~B, D, B, y+z
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, B, a+b
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, B, a+c
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, B, b+c
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, F, x+y
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, F, x+z
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, F, y+z
command.buffer.time = 10

[command]
name = "dp_ab"
command = ~F, D, F, a+b
command.buffer.time = 10

[command]
name = "dp_ab"
command = ~F, D, F, a+c
command.buffer.time = 10

[command]
name = "dp_ab"
command = ~F, D, F, b+c
command.buffer.time = 10
;=======================================================
[command]
name = "qcf_xy"
command = ~D, DF, F,x+y
command.buffer.time = 10

[command]
name = "qcf_xy"
command = ~D, DF, F,x+z
command.buffer.time = 10

[command]
name = "qcf_xy"
command = ~D, DF, F,y+z
command.buffer.time = 10

[command]
name = "qcf_ab"
command = ~D, DF, F,a+b
command.buffer.time = 10

[command]
name = "qcf_ab"
command = ~D, DF, F,b+c
command.buffer.time = 10

[command]
name = "qcf_ab"
command = ~D, DF, F,a+c
command.buffer.time = 10

[command]
name = "qcb_ab"
command = ~D, DB, B,a+b
command.buffer.time = 10

[command]
name = "qcb_ab"
command = ~D, DB, B,b+c
command.buffer.time = 10

[command]
name = "qcb_ab"
command = ~D, DB, B,a+c
command.buffer.time = 10

[command]
name = "qcb_xy"
command = ~D, DB, B,x+y
command.buffer.time = 10

[command]
name = "qcb_xy"
command = ~D, DB, B,x+z
command.buffer.time = 10

[command]
name = "qcb_xy"
command = ~D, DB, B,y+z
command.buffer.time = 10

;taunt--------------------------------------------------

[Command]
name = "taunt"
command = s

;Team Commands---------------------

[Command]
name = "Double"
command = ~D, DF, F, c+z
command.buffer.time = 10

[Command]
name = "SDouble"
command = ~D, DB, B,c+z
command.buffer.time = 10

[Command]
name = "tag"
command = c+z
command.buffer.time = 10

[Command]
name = "assist"
command = s
command.buffer.time = 10

[Command]
name = "snap"
command = ~D, DF, F,s
command.buffer.time = 10

[Command]
name = "baroque"
command = y+b

;-| DoUBle tap |-----------------------------------------------------------
[command]
name = "ff"     ;required (do not remove)
command = F, F
time = 15

[command]
name = "bb"     ;required (do not remove)
command = B, B
time = 15

;-| Counter |------------

[command]
name = "counter"
command = /F, z+c
time = 8

;-| super jump |-----------------------------------------------------------
[command]
name = "du"
command = $D, $U
time = 15

[command]
name = "abc"
command = a+b
time = 8

[command]
name = "abc"
command = a+c
time = 8

[command]
name = "abc"
command = b+c
time = 8

[command]
name = "xyz"
command = x+y
time = 8

[command]
name = "xyz"
command = x+z
time = 8

[command]
name = "xyz"
command = y+z
time = 8

;-| single button |---------------------------------------------------------
[command]
name = "a"
command = a
time = 1

[command]
name = "b"
command = b
time = 1

[command]
name = "c"
command = c
time = 1

[command]
name = "x"
command = x
time = 1

[command]
name = "y"
command = y
time = 1

[command]
name = "z"
command = z
time = 1

[command]
name = "fwd"
command = F
time = 1

[command]
name = "back"
command = B
time = 1

[command]
name = "up"
command = U
time = 1
command.buffer.time = 10

[command]
name = "down"
command = D
time = 1

;-| hold Dir |--------------------------------------------------------------
[command]
name = "holdfwd";required (do not remove)
command = /$F
time = 1

[command]
name = "holdback";required (do not remove)
command = /$B
time = 1

[command]
name = "holdup" ;required (do not remove)
command = /$U
time = 1

[command]
name = "holddown";required (do not remove)
command = /$D
time = 1

;Special individuals' Motions--------------------------------------------------------------------

[command]
name = "aaa"
command = a,a,a
time = 35
command.buffer.time = 10

[command]
name = "bbb"
command = b,b,b,b
time = 35
command.buffer.time = 10

[command]
name = "ccc"
command = c,c,c,c,c
time = 35
command.buffer.time = 10

[command]
name = "xxx"
command = x,x,x
time = 35
command.buffer.time = 10

[command]
name = "yyy"
command = y,y,y,y
time = 35
command.buffer.time = 10

[command]
name = "zzz"
command = z,z,z,z,z
time = 35
command.buffer.time = 10

[command]
name = "dd_xyz"
command = D,D, x+y
time = 15
command.buffer.time = 10

[command]
name = "dd_xyz"
command = D,D, y+z
time = 15
command.buffer.time = 10

[command]
name = "dd_xyz"
command = D,D, x+z
time = 15
command.buffer.time = 10

[command]
name = "dd_abc"
command = D,D, a+b
time = 15
command.buffer.time = 10

[command]
name = "dd_abc"
command = D,D, b+c
time = 15
command.buffer.time = 10

[command]
name = "dd_abc"
command = D,D, a+c
time = 15
command.buffer.time = 10

[command]
name = "dd_x"
command = D,D, x
time = 15
command.buffer.time = 10

[command]
name = "dd_y"
command = D,D, y
time = 15
command.buffer.time = 10

[command]
name = "dd_z"
command = D,D, z
time = 15
command.buffer.time = 10

[command]
name = "dd_a"
command = D,D, a
time = 15
command.buffer.time = 10

[command]
name = "dd_b"
command = D,D, b
time = 15
command.buffer.time = 10

[command]
name = "dd_c"
command = D,D, c
time = 15
command.buffer.time = 10

[command]
name = "PMJH"
command = c, y, D, b,z
time = 40
command.buffer.time = 10

[Command]
name="slumber"
command=x,b,B,y,c
time=45

[command]
name = "shun"
command = x,x,F,a,z
time = 35
command.buffer.time = 10

[command]
name ="black"
command = y,z,B,b,c
time = 40
command.buffer.time = 10

[command]
name = "BFXY"
command = B, F, x+y
command.buffer.time = 10

[command]
name = "BFXY"
command = B, F, y+z
command.buffer.time = 10

[command]
name = "BFXY"
command = B, F, x+z
command.buffer.time = 10

[command]
name = "airjump"
command = U
time = 1
command.buffer.time = 10

[command]
name = "airjump"
command = UF
time = 1
command.buffer.time = 10

[command]
name = "airjump"
command = UB
time = 1
command.buffer.time = 10

[command]
name = "BF"
command = B, F

[command]
name = "uf_a"
command = ~U, F, a
command.buffer.time = 10

[command]
name = "uf_b"
command = ~U, F, b
command.buffer.time = 10

[command]
name = "uf_c"
command = ~U, F, c
command.buffer.time = 10

[command]
name = "bf_x"
command = B, F, x
command.buffer.time = 10

[command]
name = "bf_y"
command = B, F, y
command.buffer.time = 10

[command]
name = "bf_z"
command = B, F, z
command.buffer.time = 10

;Negative Edge ---------------------------------------------------------------------------------------------------------

;-| special motions |--------------------------------------------------------
[command]
name = "charge_x"
command = ~40$B,F,~x
time = 15
command.buffer.time = 10

[command]
name = "charge_y"
command = ~40$B,F,~y
time = 15
command.buffer.time = 10

[command]
name = "charge_z"
command = ~40$B,F,~z
time = 15
command.buffer.time = 10

[command]
name = "vcharge_x"
command = ~40$D,U,~x
time = 15
command.buffer.time = 10

[command]
name = "vcharge_y"
command = ~40$D,U,~y
time = 15
command.buffer.time = 10

[command]
name = "vcharge_z"
command = ~40$D,U,~z
time = 15
command.buffer.time = 10

[command]
name = "vcharge_a"
command = ~40$D,U,~a
time = 15
command.buffer.time = 10

[command]
name = "vcharge_b"
command = ~40$D,U,~b
time = 15
command.buffer.time = 10

[command]
name = "vcharge_c"
command = ~40$D,U,~c
time = 15
command.buffer.time = 10

[command]
name = "charge_a"
command = ~40$B,F,~a
time = 15
command.buffer.time = 10

[command]
name = "charge_b"
command = ~40$B,F,~b
time = 15
command.buffer.time = 10

[command]
name = "charge_c"
command = ~40$B,F,~c
time = 15
command.buffer.time = 10

[command]
name = "DUa"
command = $D,U,~a
time = 15
command.buffer.time = 10

[command]
name = "DUb"
command = $D,U,~b
time = 15
command.buffer.time = 10

[command]
name = "DUc"
command = $D,U,~c
time = 15
command.buffer.time = 10

[command]
name = "hold x"
command = /$x
time = 1

[command]
name = "hold y"
command = /$y
time = 1

[command]
name = "hold z"
command = /$z
time = 1

[command]
name = "hold a"
command = /$a
time = 1

[command]
name = "hold b"
command = /$b
time = 1

[command]
name = "hold c"
command = /$c
time = 1

[command]
name = "rdp_x"
command = ~B, D, DB, ~x
command.buffer.time = 10

[command]
name = "rdp_y"
command = ~B, D, DB, ~y
command.buffer.time = 10

[command]
name = "rdp_z"
command = ~B, D, DB, ~z
command.buffer.time = 10

[command]
name = "rdp_a"
command = ~B, D, DB, ~a
command.buffer.time = 10

[command]
name = "rdp_b"
command = ~B, D, DB, ~b
command.buffer.time = 10

[command]
name = "rdp_c"
command = ~B, D, DB, ~c
command.buffer.time = 10

[command]
name = "dp_x"
command = ~F, D, DF, ~x
command.buffer.time = 10

[command]
name = "dp_y"
command = ~F, D, DF, ~y
command.buffer.time = 10

[command]
name = "dp_z"
command = ~F, D, DF, ~z
command.buffer.time = 10

[command]
name = "dp_a"
command = ~F, D, DF, ~a
command.buffer.time = 10

[command]
name = "dp_b"
command = ~F, D, DF, ~b
command.buffer.time = 10

[command]
name = "dp_c"
command = ~F, D, DF, ~c
command.buffer.time = 10

;====================================================================
[command]
name = "hcb_x"
command = ~F, D, B, ~x
time = 30
command.buffer.time = 10

[command]
name = "hcb_y"
command = ~F, D, B, ~y
time = 30
command.buffer.time = 10

[command]
name = "hcb_z"
command = ~F, D, B, ~z
time = 30
command.buffer.time = 10

[command]
name = "hcb_a"
command = ~F, D, B, ~a
time = 40
command.buffer.time = 10

[command]
name = "hcb_b"
command = ~F, D, B, ~b
time = 40
command.buffer.time = 10

[command]
name = "hcb_c"
command = ~F, D, B, ~c
time = 40
command.buffer.time = 10

[command]
name = "qcb_x"
command = ~D, DB, B,~x
command.buffer.time = 10

[command]
name = "qcb_y"
command = ~D, DB, B,~y
command.buffer.time = 10

[command]
name = "qcb_z"
command = ~D, DB, B,~z
command.buffer.time = 10

[command]
name = "qcb_a"
command = ~D, DB, B,~a
command.buffer.time = 10

[command]
name = "qcb_b"
command = ~D, DB, B,~b
command.buffer.time = 10

[command]
name = "qcb_c"
command = ~D, DB, B,~c
command.buffer.time = 10

[command]
name = "qcf_x"
command = ~D, DF, F,~x
command.buffer.time = 10

[command]
name = "qcf_y"
command = ~D, DF, F,~y
command.buffer.time = 10

[command]
name = "qcf_z"
command = ~D, DF, F,~z
command.buffer.time = 10

[command]
name = "qcf_a"
command = ~D, DF, F,~a
command.buffer.time = 10

[command]
name = "qcf_b"
command = ~D, DF, F,~b
command.buffer.time = 10

[command]
name = "qcf_c"
command = ~D, DF, F,~c
command.buffer.time = 10

;360--------------------------------------------------------------------------------
[Command]
name = "360_x"
command = ~F, D, B, /$U, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~D, B, U, /$F, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~B, U, F, /$D, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~U, F, D, /$B, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~F, U, B, /$D, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~D, F, U, /$B, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~B, D, F, /$U, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_x"
command = ~U, B, D, /$F, ~x
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~F, D, B, /$U, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~D, B, U, /$F, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~B, U, F, /$D, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~U, F, D, /$B, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~F, U, B, /$D, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~D, F, U, /$B, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~B, D, F, /$U, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_y"
command = ~U, B, D, /$F, ~y
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~F, D, B, /$U, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~D, B, U, /$F, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~B, U, F, /$D, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~U, F, D, /$B, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~F, U, B, /$D, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~D, F, U, /$B, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~B, D, F, /$U, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_z"
command = ~U, B, D, /$F, ~z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, D, B, /$U, ~x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, B, U, /$F, ~x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, U, F, /$D, ~x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, F, D, /$B, ~x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, U, B, /$D, ~x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, F, U, /$B, ~x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, D, F, /$U, ~x+y
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, B, D, /$F, ~x+y
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, D, B, /$U, ~y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, B, U, /$F, ~y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, U, F, /$D, ~y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, F, D, /$B, ~y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, U, B, /$D, ~y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, F, U, /$B, ~y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, D, F, /$U, ~y+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, B, D, /$F, ~y+z
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, D, B, /$U, ~x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, B, U, /$F, ~x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, U, F, /$D, ~x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, F, D, /$B, ~x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~F, U, B, /$D, ~x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~D, F, U, /$B, ~x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~B, D, F, /$U, ~x+z
time = 30
command.buffer.time = 10

[Command]
name = "360_xy"
command = ~U, B, D, /$F, ~x+z
command.buffer.time = 10

;super motions----------------------------------------------------------------------


[command]
name = "rdp_xy"
command = ~B, D, DB, x+y
command.buffer.time = 10

[command]
name = "rdp_xy"
command = ~B, D, DB, x+z
command.buffer.time = 10

[command]
name = "rdp_xy"
command = ~B, D, DB, y+z
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, DB, a+b
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, DB, a+c
command.buffer.time = 10

[command]
name = "rdp_ab"
command = ~B, D, DB, b+c
command.buffer.time = 10

;==================================================================
[command]
name = "dp_xy"
command = ~F, D, DF, ~x+y
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, DF, ~x+z
command.buffer.time = 10

[command]
name = "dp_xy"
command = ~F, D, DF, ~y+z
command.buffer.time = 10
;====================================================================
[command]
name = "qcf_xy"
command = ~D, DF, F,~x+y
command.buffer.time = 10

[command]
name = "qcf_xy"
command = ~D, DF, F,~x+z
command.buffer.time = 10

[command]
name = "qcf_xy"
command = ~D, DF, F,~y+z
command.buffer.time = 10

[command]
name = "qcf_ab"
command = ~D, DF, F,~a+b
command.buffer.time = 10

[command]
name = "qcf_ab"
command = ~D, DF, F,~b+c
command.buffer.time = 10

[command]
name = "qcf_ab"
command = ~D, DF, F,~a+c
command.buffer.time = 10

[command]
name = "qcb_ab"
command = ~D, DB, B,~a+b
command.buffer.time = 10

[command]
name = "qcb_ab"
command = ~D, DB, B,~b+c
command.buffer.time = 10

[command]
name = "qcb_ab"
command = ~D, DB, B,~a+c
command.buffer.time = 10

[command]
name = "qcb_xy"
command = ~D, DB, B,~x+y
command.buffer.time = 10

[command]
name = "qcb_xy"
command = ~D, DB, B,~x+z
command.buffer.time = 10

[command]
name = "qcb_xy"
command = ~D, DB, B,~y+z
command.buffer.time = 10


;-| Counter |------------

[Command]
name = "recovery";Required (do not remove)
command = x+y
time = 1

[Command]
name = "undizzy"
command = ~B, F, B, F, B, F, B, F
time = 35

[Command]
name = "undizzy"
command = ~D, U, D, U, D, U, D, U
time = 35

;-| PartnerChange |------------

[command]
name = "counter"
command = /F, x+a
time = 8

[command]
name = "counter"
command = /F, y+b
time = 8

[command]
name = "counter"
command = /F, z+c
time = 8

;-| super jump |-----------------------------------------------------------
[command]
name = "du"
command = ~D, $U
time = 8

[command]
name = "abc"
command = b+c
time = 8

[command]
name = "abc"
command = a+b
time = 8

;-| push back |-----------------------------------------------------------
[command]
name = "guardpush"
command = x+y
time = 10

[command]
name = "guardpush"
command = x+z
time = 10

[command]
name = "guardpush"
command = z+y
time = 10
;-| single button |---------------------------------------------------------
[command]
name = "a"
command = a
time = 1

[command]
name = "b"
command = b
time = 1

[command]
name = "c"
command = c
time = 1

[command]
name = "x"
command = x
time = 1

[command]
name = "y"
command = y
time = 1

[command]
name = "z"
command = z
time = 1

[command]
name = "fwd"
command = F
time = 1

[command]
name = "back"
command = B
time = 1

[command]
name = "up"
command = U
time = 1

[command]
name = "down"
command = D
time = 1

;-| hold Dir |--------------------------------------------------------------
[command]
name = "holdfwd";required (do not remove)
command = /$F
time = 1

[command]
name = "holdback";required (do not remove)
command = /$B
time = 1

[command]
name = "holdup" ;required (do not remove)
command = /$U
time = 1

[command]
name = "holddown";required (do not remove)
command = /$D
time = 1

;Special individuals' Motions--------------------------------------------------------------------


[command]
name = "BFXY"
command = B, F, x+y
command.buffer.time = 10

[command]
name = "BFXY"
command = B, F, ~y+z
command.buffer.time = 10

[command]
name = "BFXY"
command = B, F, ~x+z
command.buffer.time = 10

[command]
name = "airjump"
command = $U
time = 1
command.buffer.time = 10

[command]
name = "BF"
command = B, F


[command]
name = "bf_x"
command = B, F, ~x
command.buffer.time = 10

[command]
name = "bf_y"
command = B, F, ~y
command.buffer.time = 10

[command]
name = "bf_z"
command = B, F, ~z
command.buffer.time = 10



;---------------------------------------------------------------------------------------------------------

;---------------------------------------------------------------------------------------------------------

[statedef -1]

[State -1, Stand]
type = ChangeState
value = 45
triggerall = command = "airjump"
triggerall = var(59) = 0
triggerall = var(53) = 2
triggerall = var(20) > 2
trigger1 = (stateno = [600,650])
trigger1 = movehit
ignorehitpause = 1

;---------------------------------------------------------------------------
; ragnarok
[state -1, ragnarok]
type = changestate
value = 3200
triggerall = command = "dp_xy"
triggerall = statetype != A 
triggerall = power >= 1000
trigger1 = ctrl
trigger2 = stateno = [200,459]
trigger2 = movehit
trigger3 = stateno = 2170 || stateno = 2550
;trigger4 = stateno = [2330,2350]
;trigger5 = stateno = [2000,2020]
;trigger6 = stateno = [2030,2040]

;---------------------------------------------------------------------------
; ouroboros
; Ouroboros
[State -1, Ouroboros]
type = ChangeState
value = 3000
triggerall = !var(26)
triggerall = var(24) = 0
triggerall = command = "qcf_xy"
triggerall = StateType = S || StateType = C
triggerall = Power >= 1000
triggerall = NumHelper(5643) = 0
trigger1 = ctrl
trigger2 = StateNo = [200,350]
trigger3 = StateNo = 2170 || StateNo = 2550
trigger4 = StateNo = [2330,2350]
trigger5 = StateNo = [2000,2010]
trigger6 = StateNo = [2030,2040]



;---------------------------------------------------------------------------
; legion
[state -1, legion]
type = changestate
value = 3040
triggerall = command = "qcf_ab"
triggerall = statetype != A 
triggerall = power >= 1000
triggerall = numhelper(7752) = 0
triggerall = (p2stateno != 3045 && p2stateno != 3046) || p2movetype != h
trigger1 = ctrl
trigger2 = stateno = [200,459]
trigger2 = movehit
trigger3 = stateno = 2170 || stateno = 2550
;trigger4 = stateno = [2330,2350]
;trigger5 = stateno = [2000,2020]
;trigger6 = stateno = [2030,2040]

;===========================================================================


;---------------------------------------------------------------------------
; gram air
[state -1, gram air]
type = changestate
value = 2050
triggerall = command = "dp_x" || command = "dp_y" || command = "dp_z"
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]

;--------------------------------------------------------------------------
; excalibur x
[state -1, excalibur x]
type = changestate
value = 2400
triggerall = command = "qcf_x"
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]
trigger3 = stateno = 500

;--------------------------------------------------------------------------
; excalibur y
[state -1, excalibur y]
type = changestate
value = 2450
triggerall = command = "qcf_y"
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]
trigger3 = stateno = 500

;--------------------------------------------------------------------------
; excalibur y
[state -1, excalibur y]
type = changestate
value = 2470
triggerall = command = "qcf_z"
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]
trigger3 = stateno = 500

;--------------------------------------------------------------------------
; excalibur a
[state -1, excalibur a]
type = changestate
value = 2490
triggerall = command = "qcf_a"
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]
trigger3 = stateno = 500

;--------------------------------------------------------------------------
; excalibur b
[state -1, excalibur b]
type = changestate
value = 2510
triggerall = command = "qcf_b"
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]
trigger3 = stateno = 500

;--------------------------------------------------------------------------
; excalibur c
[state -1, excalibur c]
type = changestate
value = 2530
triggerall = command = "qcf_c"
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]
trigger3 = stateno = 500

;---------------------------------------------------------------------------
; warp lp
[state -1, warp lp]
type = changestate
value = 2300
triggerall = command = "rdp_x"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; warp mp
[state -1, warp mp]
type = changestate
value = 2301
triggerall = command = "rdp_y"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; warp hp
[state -1, warp hp]
type = changestate
value = 2302
triggerall = command = "rdp_z"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; warp lk
[state -1, warp lk]
type = changestate
value = 2303
triggerall = command = "rdp_a"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; warp mk
[state -1, warp mk]
type = changestate
value = 2304
triggerall = command = "rdp_b"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; warp hk
[state -1, warp hk]
type = changestate
value = 2305
triggerall = command = "rdp_c"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; kabe haritsuki
[state -1, kabe haritsuki]
type = changestate
value = 2060
triggerall = command = "qcb_x" || command = "qcb_y" || command = "qcb_z"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; vajra a
[state -1, vajra a]
type = changestate
value = 2270
triggerall = command = "qcb_a"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; vajra b
[state -1, vajra b]
type = changestate
value = 2271
triggerall = command = "qcb_b"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; vajra c
[state -1, vajra c]
type = changestate
value = 2272
triggerall = command = "qcb_c"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; gram standing
[state -1, gram standing]
type = changestate
value = 2030
triggerall = command = "dp_x" || command = "dp_y" || command = "dp_z"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; gram crouching
[state -1, gram crouching]
type = changestate
value = 2040
triggerall = command = "dp_a" || command = "dp_b" || command = "dp_c"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; Formation a
[state -1, Formation a]
type = changestate
value = 2170
triggerall = command = "qcf_a" || command = "qcf_b"
triggerall = numhelper(7307) = 0
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; Formation a Falcon
[state -1, Formation a Falcon]
type = changestate
value = 2550
triggerall = command = "qcf_c"
triggerall = numhelper(7308) = 0
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; ame-no-murakumo x
[state -1, Dash slash x]
type = changestate
value = 2000
triggerall = command = "qcf_x"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; ame-no-murakumo y
[state -1, Dash slash y]
type = changestate
value = 2010
triggerall = command = "qcf_y"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; ame-no-murakumo z
[state -1, Dash slash z]
type = changestate
value = 2020
triggerall = command = "qcf_z"
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; Formation b - release stand
[state -1, Formation b release stand]
type = changestate
value = 2210
triggerall = command = "charge_x" || command = "charge_y" || command = "charge_z"
triggerall = numhelper(8135) > 0
triggerall = helper(8135), stateno = 2230
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; Formation b - release air
[state -1, Formation b]
type = changestate
value = 2220
triggerall = command = "charge_x" || command = "charge_y" || command = "charge_z"
triggerall = numhelper(8135) > 0
triggerall = helper(8135), stateno = 2230
triggerall = statetype = a
trigger1 = ctrl
trigger2 = stateno = [600,650]

;---------------------------------------------------------------------------
; Formation b
[state -1, Formation b]
type = changestate
value = 2200
triggerall = command = "charge_x" || command = "charge_y" || command = "charge_z"
triggerall = numhelper(8135) = 0
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; Formation c lk
[state -1, Formation c lk]
type = changestate
value = 2330
triggerall = command = "charge_a"
triggerall = numhelper(5198) = 0
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; Formation c mk
[state -1, Formation c mk]
type = changestate
value = 2340
triggerall = command = "charge_b"
triggerall = numhelper(5198) = 0
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]

;---------------------------------------------------------------------------
; Formation c hk
[state -1, Formation c hk]
type = changestate
value = 2350
triggerall = command = "charge_c"
triggerall = numhelper(5198) = 0
triggerall = statetype = s || statetype = c
trigger1 = ctrl
trigger2 = stateno = [200,450]








;BIG IKOT
[State -1, BAD IKOT]
type = ChangeState
value = 800
triggerall = var(9) != 1
triggerall = command = "z"
triggerall = statetype = S
triggerall = ctrl
triggerall = stateno != 100
trigger1 = command = "holdfwd" || command = "holdback"
trigger1 = p2bodydist X < 5
trigger1 = (p2statetype = S) || (p2statetype = C)
trigger1 = p2movetype != H

;-----------------------------------------------

;BIG EAT
[State -1, BAD EAT]
type = ChangeState
value = 850
triggerall = var(9) != 1
triggerall = command = "c"
triggerall = statetype = S
triggerall = ctrl
triggerall = stateno != 100
trigger1 = command = "holdfwd" || command = "holdback"
trigger1 = p2bodydist X < 5
trigger1 = (p2statetype = S) || (p2statetype = C)
trigger1 = p2movetype != H


;BIG EAT
[State -1, BAD EAT]
type = ChangeState
value = 1130
triggerall = var(9) != 1
triggerall = command = "z"
triggerall = statetype = A
triggerall = ctrl
triggerall = stateno != 100
trigger1 = command = "holdfwd" || command = "holdback"
trigger1 = p2bodydist X < 5
trigger1 = (p2statetype = A)
trigger1 = p2movetype != H
trigger1 = p2bodydist X < 3



;---------------------------------------------------------------------------

;run Fwd
;ƒ_ƒbƒvƒ…
[state -1, run Fwd]
type = changestate
value = 100
triggerall = statetype = S && (stateno !=[100,106])
triggerall = ctrl
trigger1 = (command = "ff")
trigger2 = (command = "xyz") && (command != "holdback")
;---------------------------------------------------------------------------
;run back
;œã‘þƒ_ƒbƒvƒ…
[state -1, run back]
type = changestate
value = 105
triggerall = (statetype = s) && (stateno !=[100,106])
triggerall = ctrl
trigger1 = command = "bb"
trigger2 = (command = "xyz") && (command = "holdback")

;===========================================================================
;jump strong kick
[state -1]
type = changestate
value = 40
triggerall = var(53) = 1
triggerall = command = "abc" || command = "du"
triggerall = statetype != a
trigger1 = ctrl
trigger2 = stateno = [200,450]
trigger2 = movehit

;---------------------------------------------------------------------------
;taunt
;’§”­
[state -1, taunt]
type = changestate
value = 195
triggerall = var(53) != 2
triggerall = command = "taunt"
trigger1 = statetype != a
trigger1 = ctrl

;---------------------------------------------------------------------------
;stand light punch
[state -1]
type = changestate
value = 200
triggerall = command = "x"
triggerall = command != "holddown"
trigger1 = statetype = s
trigger1 = ctrl

;---------------------------------------------------------------------------
;stand medium punch

[state -1]
type = changestate
value = 210
triggerall = command = "y"
triggerall = command != "holddown"
trigger1 = statetype = s
trigger1 = ctrl
trigger2 = (stateno = 200) && movecontact
trigger3 = (stateno = 230) && movecontact
trigger4 = (stateno = 400) && movecontact
trigger5 = (stateno = 430) && movecontact
trigger6 = stateno = [100,106]

;---------------------------------------------------------------------------
;stand strong punch
[state -1]
type = changestate
value = 220
triggerall = command = "z"
triggerall = command != "holddown"
trigger1 = statetype = s
trigger1 = ctrl && stateno != [100,106]
trigger2 = (stateno = [200,210]) && movecontact
trigger3 = (stateno = [230,240]) && movecontact
trigger4 = (stateno = [400,410]) && movecontact
trigger5 = (stateno = [430,440]) && movecontact
trigger6 = (stateno = [100,106]) && command != "holdfwd"

;---------------------------------------------------------------------------
;stand light kick
[state -1]
type = changestate
value = 230
triggerall = command = "a"
triggerall = command != "holddown"
trigger1 = statetype = s
trigger1 = ctrl
trigger2 = (stateno = 200) && movecontact
trigger3 = (stateno = 400) && movecontact
;---------------------------------------------------------------------------
;standing strong kick

[state -1]
type = changestate
value = 240
triggerall = command = "b"
triggerall = command != "holddown"
triggerall = statetype != A
trigger1 = ctrl
trigger1 = stateno != [100,101]
trigger2 = (stateno = [200,210]) && movecontact
trigger3 = (stateno = 230) && movecontact
trigger4 = (stateno = [400,410]) && movecontact
trigger5 = (stateno = 430) && movecontact
trigger6 = stateno = [100,101]

;---------------------------------------------------------------------------
;standing strong kick
[state -1]
type = changestate
value = 250
triggerall = command = "c"
triggerall = command != "holddown"
trigger1 = statetype = s
trigger1 = ctrl
trigger2 = (stateno = [200,220]) && movecontact
trigger3 = (stateno = [230,240]) && movecontact
trigger4 = (stateno = [400,420]) && movecontact
trigger5 = (stateno = [430,440]) && movecontact

[state -1]
type = changestate
value = 451
triggerall = command = "c"
triggerall = (command = "holddown") && (command = "holdfwd")
triggerall = statetype != A
trigger1 = ctrl = 1
trigger2 = (stateno = [200,220]) && movecontact
trigger3 = (stateno = [230,240]) && movecontact
trigger4 = (stateno = [400,420]) && movecontact
trigger5 = (stateno = [430,440]) && movecontact
;---------------------------------------------------------------------------
;crouching light punch
[state -1, crouching light punch]
type = changestate
value = 400
triggerall = command = "x"
triggerall = command = "holddown"
trigger1 = statetype = c
trigger1 = ctrl

;---------------------------------------------------------------------------
;crouching medium punch
[state -1, crouching medium punch]
type = changestate
value = 410
triggerall = command = "y"
triggerall = command = "holddown"
trigger1 = statetype = c
trigger1 = ctrl
trigger2 = (stateno = 200) && movecontact
trigger3 = (stateno = 230) && movecontact
trigger4 = (stateno = 400) && movecontact
trigger5 = (stateno = 430) && movecontact
;---------------------------------------------------------------------------
;crouching strong punch
[state -1, crouching strong punch]
type = changestate
value = 420
triggerall = command = "z"
triggerall = command = "holddown"
trigger1 = statetype = c
trigger1 = ctrl
trigger2 = (stateno = [200,210]) && movecontact
trigger3 = (stateno = [230,240]) && movecontact
trigger4 = (stateno = [400,410]) && movecontact
trigger5 = (stateno = [430,440]) && movecontact

;---------------------------------------------------------------------------
;crouching light kick
[state -1, crouching light kick]
type = changestate
value = 430
triggerall = command = "a"
triggerall = command = "holddown"
trigger1 = statetype = c
trigger1 = ctrl
trigger2 = (stateno = 200) && movecontact
trigger3 = (stateno = 400) && movecontact

;---------------------------------------------------------------------------
;crouching medium kick
[state -1, crouching medium kick]
type = changestate
value = 440
triggerall = command = "b"
triggerall = command = "holddown"
trigger1 = statetype = c
trigger1 = ctrl
trigger2 = (stateno = [200,210]) && movecontact
trigger3 = (stateno = 230) && movecontact
trigger4 = (stateno = [400,410]) && movecontact
trigger5 = (stateno = 430) && movecontact
;---------------------------------------------------------------------------
;crouching strong kick
[state -1, crouching strong kick]
type = changestate
value = 450
triggerall = command = "c"
triggerall = command = "holddown"
trigger1 = statetype = c
trigger1 = ctrl
trigger2 = (stateno = [200,220]) && movecontact
trigger3 = (stateno = [230,240]) && movecontact
trigger4 = (stateno = [400,420]) && movecontact
trigger5 = (stateno = [430,440]) && movecontact
;---------------------------------------------------------------------------

;jump light punch
[state -1]
type = changestate
value = 600
triggerall = var(59) = 0
triggerall = command = "x"
trigger1 = statetype = a
trigger1 = ctrl

;---------------------------------------------------------------------------
;jump medium punch
[state -1]
type = changestate
value = 610
triggerall = var(59) = 0
triggerall = command = "y"
trigger1 = statetype = a
trigger1 = ctrl
trigger2 = (stateno = 600) && movecontact
trigger3 = (stateno = 630) && movecontact

;---------------------------------------------------------------------------
;jump strong punch
[state -1]
type = changestate
value = 620
triggerall = var(59) = 0
triggerall = command = "z"
trigger1 = statetype = a
trigger1 = ctrl
trigger2 = (stateno = 600) && movecontact
trigger3 = (stateno = 610) && movecontact
trigger4 = (stateno = 630) && movecontact
trigger5 = (stateno = 640) && movecontact

;---------------------------------------------------------------------------
;jump light kick
[state -1]
type = changestate
value = 630
triggerall = var(59) = 0
triggerall = command = "a"
trigger1 = statetype = a
trigger1 = ctrl
trigger2 = (stateno = 600) && movecontact
;---------------------------------------------------------------------------
;jump medium kick
[state -1]
type = changestate
value = 640
triggerall = var(59) = 0
triggerall = command = "b"
trigger1 = statetype = a
trigger1 = ctrl
trigger2 = (stateno = 600) && movecontact
trigger3 = (stateno = 610) && movecontact
trigger4 = (stateno = 630) && movecontact
;---------------------------------------------------------------------------
;jump strong kick
[state -1]
type = changestate
value = 650
triggerall = var(59) = 0
triggerall = command = "c"
trigger1 = statetype = a
trigger1 = ctrl
trigger2 = (stateno = [600,640]) && movecontact

[State -1,Wall Jump]
type = ChangeState
value = 123
triggerall = var(23) != 1
trigger1 = ((backEdgeDist) > -10 && (backEdgeDist) < 2)
triggerall = Pos Y <= -50
triggerall = Vel X != 0
triggerall = statetype = A
triggerall = ctrl = 1
triggerall = stateno != 107
triggerall = stateno != 460
trigger1 = command = "holdfwd"
trigger2 = ((frontEdgeDist) > -10 && (frontEdgeDist) < 2)
trigger2 = command = "holdback"


;counter strike 1
[state -1, counter]
type = changestate
value = 910
triggerall = (command = "counter") && (power >= 1000)
trigger1 = stateno = [150,153]


[state -1, guard push]
type = changestate
value = 555
triggerall = command = "guardpush"
triggerall = statetype = S
trigger1 = stateno = [150,153] ;the guard state numbers

[state -1, guard push]
type = changestate
value = 577
triggerall = command = "guardpush"
triggerall = statetype = A
trigger1 = stateno = [154,155] ;the guard state numbers

[state -1, guard push]
type = changestate
value = 566
triggerall = command = "guardpush"
triggerall = statetype = C
trigger1 = stateno = [151,153] ;the guard state numbers


[State -1, Forward Recovery Roll]
type = ChangeState
value = 890
triggerall = var(59) = 0
triggerall = command = "holdfwd"
triggerall = time = 1
triggerall = life > 0
trigger1 = stateno = 5120
trigger1 = alive = 1

[State -1, Backward Recovery Roll]
type = ChangeState
value = 895
triggerall = var(59) = 0
triggerall = command = "holdback"
triggerall = time = 1
triggerall = life > 0
trigger1 = stateno = 5120
trigger1 = alive = 1
