async function routes(fastify, options) {

  fastify.get("/:id", async (request, reply) => {
    result = [];
    let collection = fastify.mongo.db.collection("blackboard");
    let blackboard = await collection.find().toArray();

    collection = fastify.mongo.db.collection("furniture");
    let furniture = await collection.find().toArray();

    collection = fastify.mongo.db.collection("office");
    let office = await collection.find().toArray();

    collection = fastify.mongo.db.collection("strudentsWorkspace");
    let strudentsWorkspace	 = await collection.find().toArray();

    collection = fastify.mongo.db.collection("teacherWorkspace");
    let teacherWorkspace = await collection.find().toArray();

    result.push(blackboard, furniture, office, strudentsWorkspace, teacherWorkspace);
    if (result.length === 0) {
      throw new Error("No documents found");
    }
    return result;
  });

  fastify.get("/furniture/:name/:flour", async (request, reply) => {
    const collection = fastify.mongo.db.collection("furniture");
    const result = await collection.findOne({
      name: request.params.name,
      flour: parseInt( request.params.flour ),
    });
    if (result === null) {
      throw new Error("Invalid value");
    }
    return result;
  });

  fastify.get("/agregation/:width/:limit", async (request, reply) => {
    const pipeline = [
      {
        $lookup: {
          from: "blackboard",
          localField: "blackboardId",
          foreignField: "_id",
          as: "appointment",
        },
      },
      {
        $match: {
          "appointment.width": {
            $lt: parseInt(request.params.width),
          },
        },
      },
      {
        $group: {
          _id: "$strudentsWorkspace",
          teachersWorkspace: {
            $sum: "$teachersWorkspace",
          },
        },
      },
      {
        $limit: parseInt(request.params.limit),
      },
    ];
    
    const collection = fastify.mongo.db.collection("office");
    const result = [];
    let aggCursor = collection.aggregate(pipeline);
    await aggCursor.forEach((el) => {
      result.push(el);
    });
    if (result === null) {
      throw new Error("Invalid value");
    }
    return result;
  });
}

module.exports = routes;
