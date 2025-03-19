# Azure_CosmosDB_CURD

Azure Cosmos DB is a fully managed, distributed database service provided by Microsoft Azure. It supports multiple data models, including NoSQL and relational databases, and is designed for modern app development. Some of its key features include:

Global Distribution: Data can be distributed across multiple regions for high availability and low latency.
--------------------
Multi-Model Support: It supports APIs for NoSQL, MongoDB, Apache Cassandra, PostgreSQL, and more.
-------------------
Scalability: Offers serverless computing and dynamic autoscale options to handle varying workloads.
------------
AI Integration: Simplifies AI applications by efficiently storing and querying vectors and NoSQL data.
---------------
High Performance: Provides <10ms latency for reads and writes, making it ideal for real-time applications.
----------------
Azure Cosmos DB's multi-model support is one of its standout features, enabling flexibility for developers to work with different data models based on their application needs. Here’s an overview:

Document Model: Supports JSON-like documents and provides APIs like SQL (Core), MongoDB, and Gremlin for querying and managing the data.
--------------
Graph Model: Allows the creation of graph-based data structures using the Gremlin API, perfect for scenarios like social networks or recommendation systems.
-----------
Key-Value Model: Acts as a simple key-value store, which is ideal for applications needing high-performance lookups.
---------------
Column-Family Model: Utilizes the Cassandra API to handle wide-column data stores commonly used for analytical and IoT workloads.
-------------------
Relational Model (PostgreSQL API): Adds compatibility for relational data workloads with modern cloud-native apps.
---------------------------------
The multi-model feature means you can seamlessly integrate data from different sources and query it using the APIs best suited for your app, all within one distributed and globally scalable database service.

Apart from cosmos db does any of other nosql uses key value pair?
=================================================================
Yes, many NoSQL databases apart from Azure Cosmos DB use the key-value pair model as their primary data storage mechanism. Some popular examples include:

Amazon DynamoDB: A fully managed NoSQL database service designed for key-value and document store models, often used in serverless applications.
---------------
Redis: An in-memory key-value store known for its speed. It's widely used for caching, real-time analytics, and messaging systems.
------
Cassandra: While primarily known for its wide-column store model, it also supports a key-value structure for fast lookups.
----------
Memcached: A high-performance, distributed memory object caching system, often used to speed up web applications by storing key-value data in memory.
----------
Berkeley DB: An embedded key-value database library that provides high-performance storage for smaller-scale applications.
------------

Column-Family Model in cosmos db
================================
The Column-Family Model in Azure Cosmos DB is implemented via the Cassandra API, which allows developers to work with Cosmos DB as if it were a Cassandra database. This model organizes data into rows and columns within tables, similar to a relational database but with much more flexibility and scalability.

Here are the key aspects of the Column-Family Model in Cosmos DB:

Structure:
----------
	> Data is stored in tables with rows and columns.
	> Each row has a unique key (primary key).
	> Columns can be grouped into "column families," where related data is stored together.

Example Table:

UserID   | Name       | Email           | Age
------------------------------------------------
101      | John Doe   | john@example.com| 30
102      | Jane Smith | jane@example.com| 25

Wide-Column Flexibility:
-----------------------
Unlike traditional relational databases, rows in the Column-Family Model can have a variable number of columns. This makes it efficient for storing sparse datasets.

Scalability:
-----------
Cosmos DB's globally distributed architecture ensures horizontal scaling across multiple regions, handling large volumes of data efficiently.

Use Cases:
---------
 > IoT and Time-Series Data: Organizing sensor readings or event logs.
 > Content Management Systems: Storing metadata for articles, videos, or media.
 > Analytical Applications: Storing and querying large datasets for analysis.

Key value pair model ideal
==========================
In the key-value pair model, data is stored as a simple pair of a unique key and its corresponding value. Here's an example:

Imagine an online shopping cart application. The key-value model could be used to store items in a user's cart.

Example:
	> Key: user_123_cart
	> Value: { "item1": "Smartphone", "item2": "Laptop", "item3": "Headphones" }

In this case:
------------
	> The key is a unique identifier (user_123_cart) for a specific user's cart.
	> The value is a JSON-like object containing the items in the cart.
	> This model is great for applications requiring quick lookups, as retrieving the cart for user_123 would involve directly accessing the value associated with the key.
