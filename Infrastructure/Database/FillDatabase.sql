INSERT INTO drill_blocks 
    ("name", update_date)
VALUES
    ('Drill Block 1', '2012-08-24 14:00:00 +02:00'),
    ('Drill Block 2', '2018-08-24 14:00:00 +02:00'),
    ('Drill Block 3', '2023-08-24 14:00:00 +02:00');


INSERT INTO drill_block_point_sets
    (drill_block_id, "sequence")
VALUES
    (1, '{"1,3,4", "4,6,7", "3,5,7", "3,5,8"}'),
    (2, '{"1,3,4", "4,6,7", "3,5,7", "3,5,8"}'),
    (3, '{"1,3,4", "4,6,7", "3,5,7", "3,5,8"}');


INSERT INTO holes
    (drill_block_id, "name", depth_meters)
VALUES
    (1, 'Hole 1', 156),
    (1, 'Hole 2', 47),
    (2, 'Hole 1', 58),
    (2, 'Hole 2', 368),
    (3, 'Hole 1', 257),
    (3, 'Hole 2', 221);


INSERT INTO hole_point_sets
    (hole_id, "sequence")
VALUES
    (1, '{"1,3,4", "4,6,7", "3,5,7", "3,5,8"}'),
    (2, '{"1,3,4", "4,6,7", "3,5,7", "3,5,8"}'),
    (3, '{"1,3,4", "4,6,7", "3,5,7", "3,5,8"}');