﻿DROP FUNCTION IF EXISTS finance.create_routine(_routine_code national character varying(24), _routine regproc, _order integer);

CREATE FUNCTION finance.create_routine(_routine_code national character varying(24), _routine regproc, _order integer)
RETURNS void
AS
$$
BEGIN
    IF NOT EXISTS(SELECT * FROM finance.routines WHERE routine_code=_routine_code) THEN
        INSERT INTO finance.routines(routine_code, routine_name, "order")
        SELECT $1, $2, $3;
        RETURN;
    END IF;

    UPDATE finance.routines
    SET
        routine_name = _routine,
        "order" = _order
    WHERE routine_code=_routine_code;
    RETURN;
END
$$
LANGUAGE plpgsql;
