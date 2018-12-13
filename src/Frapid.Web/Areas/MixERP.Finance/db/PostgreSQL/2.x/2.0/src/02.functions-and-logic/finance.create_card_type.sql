﻿DROP FUNCTION IF EXISTS finance.create_card_type
(
    _card_type_id       integer, 
    _card_type_code     national character varying(12),
    _card_type_name     national character varying(100)
);

CREATE FUNCTION finance.create_card_type
(
    _card_type_id       integer, 
    _card_type_code     national character varying(12),
    _card_type_name     national character varying(100)
)
RETURNS void
AS
$$
BEGIN
    IF NOT EXISTS
    (
        SELECT * FROM finance.card_types
        WHERE card_type_id = _card_type_id
    ) THEN
        INSERT INTO finance.card_types(card_type_id, card_type_code, card_type_name)
        SELECT _card_type_id, _card_type_code, _card_type_name;
    ELSE
        UPDATE finance.card_types
        SET 
            card_type_id =      _card_type_id, 
            card_type_code =    _card_type_code, 
            card_type_name =    _card_type_name
        WHERE
            card_type_id =      _card_type_id;
    END IF;
END
$$
LANGUAGE plpgsql;
