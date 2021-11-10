﻿/*
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

namespace DotPulsar.IntegrationTests.Services;

using Abstraction;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class PulsarServiceBase : IPulsarService
{
    private readonly CancellationTokenSource _cts;
    private readonly HttpClient _adminClient;

    protected PulsarServiceBase()
    {
        _cts = new CancellationTokenSource();
        _adminClient = new HttpClient();
    }

    public virtual Task InitializeAsync()
        => Task.CompletedTask;

    public virtual Task DisposeAsync()
    {
        _adminClient.Dispose();
        _cts.Dispose();
        return Task.CompletedTask;
    }

    public virtual Uri GetBrokerUri()
        => throw new NotImplementedException();

    public virtual Uri GetWebServiceUri()
        => throw new NotImplementedException();

    public async Task<HttpResponseMessage?> CreatePartitionedTopic(string restTopic, int numPartitions)
    {
        var content = new StringContent(numPartitions.ToString(), Encoding.UTF8, "application/json");
        return await _adminClient.PutAsync($"{GetWebServiceUri()}admin/v2/{restTopic}/partitions", content, _cts.Token).ConfigureAwait(false);
    }
}
