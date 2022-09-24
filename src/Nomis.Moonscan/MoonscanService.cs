using System.Net;

using Nethereum.Util;
using Nomis.Moonscan.Calculators;
using Nomis.Moonscan.Interfaces;
using Nomis.Moonscan.Interfaces.Models;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Exceptions;
using Nomis.Utils.Wrapper;

namespace Nomis.Moonscan
{
    /// <inheritdoc cref="IMoonscanService"/>
    internal sealed class MoonscanService :
        IMoonscanService,
        ITransientService
    {
        /// <summary>
        /// Initialize <see cref="MoonscanService"/>.
        /// </summary>
        /// <param name="client"><see cref="IMoonscanClient"/>.</param>
        public MoonscanService(
            IMoonscanClient client)
        {
            Client = client;
        }

        /// <inheritdoc/>
        public IMoonscanClient Client { get; }

        /// <inheritdoc/>
        public async Task<Result<MoonbeamWalletScore>> GetWalletStatsAsync(string address)
        {
            if (!new AddressUtil().IsValidAddressLength(address) || !new AddressUtil().IsValidEthereumAddressHexFormat(address))
            {
                throw new CustomException("Invalid address", statusCode: HttpStatusCode.BadRequest);
            }

            var balanceWei = (await Client.GetBalanceAsync(address)).Balance;
            var transactions = (await Client.GetTransactionsAsync<MoonscanAccountNormalTransactions, MoonscanAccountNormalTransaction>(address)).ToList();
            var internalTransactions = (await Client.GetTransactionsAsync<MoonscanAccountInternalTransactions, MoonscanAccountInternalTransaction>(address)).ToList();
            var erc20Tokens = (await Client.GetTransactionsAsync<MoonscanAccountERC20TokenEvents, MoonscanAccountERC20TokenEvent>(address)).ToList();
            var tokens = (await Client.GetTransactionsAsync<MoonscanAccountERC721TokenEvents, MoonscanAccountERC721TokenEvent>(address)).ToList();

            var walletStats = new MoonbeamStatCalculator(
                    address,
                    decimal.TryParse(balanceWei, out var wei) ? wei : 0,
                    transactions,
                    internalTransactions,
                    tokens,
                    erc20Tokens)
                .GetStats();

            return await Result<MoonbeamWalletScore>.SuccessAsync(new()
            {
                Stats = walletStats,
                Score = walletStats.GetScore()
            }, "Got moonbeam wallet score.");
        }
    }
}