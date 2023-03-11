-- CREATE DATABASE "CrudDatabase";
-- CREATE USER "CrudApp" WITH ENCRYPTED PASSWORD '1234notsecure';
-- GRANT ALL PRIVILEGES ON DATABASE "CrudDatabase" TO "CrudApp";
-- ALTER DATABASE "CrudDatabase" OWNER TO "CrudApp";

CREATE TABLE drill_blocks (
    drill_block_id SERIAL NOT NULL,
    "name" TEXT NOT NULL,
    update_date TIMESTAMP WITH TIME ZONE,
    PRIMARY KEY(drill_block_id)
);

CREATE TABLE drill_block_point_sets (
    drill_block_point_set_id SERIAL NOT NULL,
    drill_block_id INT UNIQUE,
    "sequence" TEXT[],
    PRIMARY KEY(drill_block_point_set_id),
    CONSTRAINT fk_drill_block_id
        FOREIGN KEY(drill_block_id)
            REFERENCES drill_blocks(drill_block_id) 
);

CREATE TABLE holes (
    hole_id SERIAL NOT NULL,
    drill_block_id INT,
    "name" TEXT NOT NULL,
    depth_meters INT NOT NULL,
    PRIMARY KEY(hole_id),
    CONSTRAINT fk_drill_block_id
        FOREIGN KEY(drill_block_id)
            REFERENCES drill_blocks(drill_block_id) 
);

CREATE TABLE hole_point_sets (
    hole_point_set_id SERIAL NOT NULL,
    hole_id INT UNIQUE,
    "sequence"  TEXT[],
    PRIMARY KEY(hole_point_set_id),
    CONSTRAINT fk_hole_id
        FOREIGN KEY(hole_id)
            REFERENCES holes(hole_id)
);

