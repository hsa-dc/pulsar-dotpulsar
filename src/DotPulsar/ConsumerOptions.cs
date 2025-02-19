/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace DotPulsar;

using DotPulsar.Abstractions;
using System.Collections.Generic;

/// <summary>
/// The consumer building options.
/// </summary>
public sealed class ConsumerOptions<TMessage>
{
    /// <summary>
    /// The default initial position.
    /// </summary>
    public static readonly SubscriptionInitialPosition DefaultInitialPosition = SubscriptionInitialPosition.Latest;

    /// <summary>
    /// The default message prefetch count.
    /// </summary>
    public static readonly uint DefaultMessagePrefetchCount = 1000;

    /// <summary>
    /// The default priority level.
    /// </summary>
    public static readonly int DefaultPriorityLevel = 0;

    /// <summary>
    /// The default of whether to read compacted.
    /// </summary>
    public static readonly bool DefaultReadCompacted = false;

    /// <summary>
    /// The default of whether to replicate the subscription's state.
    /// </summary>
    public static readonly bool DefaultReplicateSubscriptionState = false;

    /// <summary>
    /// The default subscription type.
    /// </summary>
    public static readonly SubscriptionType DefaultSubscriptionType = SubscriptionType.Exclusive;

    /// <summary>
    /// Initializes a new instance using the specified subscription name and topic.
    /// </summary>
    public ConsumerOptions(string subscriptionName, string topic, ISchema<TMessage> schema)
    {
        InitialPosition = DefaultInitialPosition;
        PriorityLevel = DefaultPriorityLevel;
        MessagePrefetchCount = DefaultMessagePrefetchCount;
        ReadCompacted = DefaultReadCompacted;
        ReplicateSubscriptionState = DefaultReplicateSubscriptionState;
        SubscriptionType = DefaultSubscriptionType;
        SubscriptionProperties = new Dictionary<string, string>();
        SubscriptionName = subscriptionName;
        Topic = topic;
        Schema = schema;
    }

    /// <summary>
    /// Set the consumer name. This is optional.
    /// </summary>
    public string? ConsumerName { get; set; }

    /// <summary>
    /// Set initial position for the subscription. The default is 'Latest'.
    /// </summary>
    public SubscriptionInitialPosition InitialPosition { get; set; }

    /// <summary>
    /// Number of messages that will be prefetched. The default is 1000.
    /// </summary>
    public uint MessagePrefetchCount { get; set; }

    /// <summary>
    /// Set the priority level for the shared subscription consumer. The default is 0.
    /// </summary>
    public int PriorityLevel { get; set; }

    /// <summary>
    /// Whether to read from the compacted topic. The default is 'false'.
    /// </summary>
    public bool ReadCompacted { get; set; }

    /// <summary>
    /// Whether to replicate the subscription's state across clusters (when using geo-replication). The default is 'false'.
    /// </summary>
    public bool ReplicateSubscriptionState { get; set; }

    /// <summary>
    /// Set the schema. This is required.
    /// </summary>
    public ISchema<TMessage> Schema { get; set; }

    /// <summary>
    /// Register a state changed handler. This is optional.
    /// </summary>
    public IHandleStateChanged<ConsumerStateChanged>? StateChangedHandler { get; set; }

    /// <summary>
    /// Set the subscription name for this consumer. This is required.
    /// </summary>
    public string SubscriptionName { get; set; }

    /// <summary>
    /// Add/Set the subscription's properties. This is optional.
    /// </summary>
    public Dictionary<string, string> SubscriptionProperties { get; set; }

    /// <summary>
    /// Set the subscription type for this consumer. The default is 'Exclusive'.
    /// </summary>
    public SubscriptionType SubscriptionType { get; set; }

    /// <summary>
    /// Set the topic for this consumer. This is required.
    /// </summary>
    public string Topic { get; set; }
}
