fvariable x fvariable y
fvariable zx fvariable zy
fvariable initx  -2e initx f!
fvariable inity  -1e inity f!
fvariable incx   0.04e incx f!
fvariable incy   0.1e incy f!
24 constant ysize   80 constant xsize

: xs! fdup x f! zx f! ;    : ys! fdup y f! zy f! ;
: nextx x f@ incx f@ f+ xs! y f@ zy f! ;
: nexty y f@ incy f@ f+ ys! initx f@ xs! ;
: fsq fdup f* ;    : 2sq fover fsq fover fsq ;
: next zx f@ zy f@   2sq f- x f@ f+ zx f!   f* 2e f* y f@ f+ zy f! ;
: mag zx f@ fsq zy f@ fsq f+ fsqrt ;
: mandel cr inity f@ ys!  initx f@ xs!
  ysize 0 DO  xsize 0 DO  32 126 DO
    next mag 2e f>    I 32 = or   IF I emit LEAVE THEN
  -1 +LOOP   nextx LOOP  cr nexty LOOP ;
: cmds cr ." Zoom-(I)n  Zoom-(O)ut  (Q)uit " cr
          ." (L)eft  (R)ight  (U)p  (D)own " cr ;
: f+! tuck f@ f+ swap f! ;
: f*! tuck f@ f* swap f! ;
: shiftx incx f@ f* initx f+! ;
: shifty incy f@ f* inity f+! ;
: view-adjust fdup xsize s>f 0.25e f* f* shiftx
                   ysize s>f 0.25e f* f* shifty ;
: zoom-in 1e view-adjust  0.5e incy f*!  0.5e incx f*! ;
: zoom-out 2.0e incy f*!  2.0e incx f*!  -1e view-adjust ;
: main
    page mandel cmds
    key toupper
    CASE
     [CHAR] I OF zoom-in ENDOF
     [CHAR] O OF zoom-out ENDOF
     [CHAR] L OF -4.0e shiftx ENDOF
     [CHAR] R OF  4.0e shiftx ENDOF
     [CHAR] U OF -4.0e shifty ENDOF
     [CHAR] D OF  4.0e shifty ENDOF
     [CHAR] Q OF cr ." BYE!" EXIT ENDOF
    ENDCASE recurse ;
