/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System.Collections.Generic;
using QuantConnect.Orders;

namespace QuantConnect.Securities.Positions
{
    /// <summary>
    /// Provides extension methods for <see cref="IPositionGroupBuyingPowerModel"/> to remove noise
    /// from initializing parameter classes.
    /// </summary>
    public static class PositionGroupBuyingPowerModelExtensions
    {
        /// <summary>
        /// Gets the margin currently allocated to the specified position group
        /// </summary>
        public static decimal GetMaintenanceMargin(
            this IPositionGroupBuyingPowerModel model,
            IPositionGroup positionGroup
            )
        {
            return model.GetMaintenanceMargin(
                new PositionGroupMaintenanceMarginParameters(positionGroup)
            );
        }

        /// <summary>
        /// The margin that must be held in order to change positions by the changes defined by the provided position group
        /// </summary>
        public static decimal GetInitialMarginRequirement(
            this IPositionGroupBuyingPowerModel model,
            IPositionGroup positionGroup
            )
        {
            return model.GetInitialMarginRequirement(
                new PositionGroupInitialMarginParameters(positionGroup)
            );
        }

        /// <summary>
        /// Gets the total margin required to execute the specified order in units of the account currency including fees
        /// </summary>
        public static decimal GetInitialMarginRequiredForOrder(
            this IPositionGroupBuyingPowerModel model,
            IPositionGroup positionGroup,
            Order order
            )
        {
            return model.GetInitialMarginRequiredForOrder(
                new PositionGroupInitialMarginRequiredForOrderParameters(positionGroup, order)
            );
        }

        /// <summary>
        /// Computes the impact on the portfolio's buying power from adding the position group to the portfolio. This is
        /// a 'what if' analysis to determine what the state of the portfolio would be if these changes were applied. The
        /// delta (before - after) is the margin requirement for adding the positions and if the margin used after the changes
        /// are applied is less than the total portfolio value, this indicates sufficient capital.
        /// </summary>
        /// <returns>Returns the portfolio's total portfolio value and margin used before and after the position changes are applied</returns>
        public static ReservedBuyingPowerImpact GetReservedBuyingPowerImpact(
            this IPositionGroupBuyingPowerModel model,
            IReadOnlyCollection<IPosition> contemplatedChanges
            )
        {
            return model.GetReservedBuyingPowerImpact(
                new ReservedBuyingPowerImpactParameters(contemplatedChanges)
            );
        }

        /// <summary>
        /// Computes the margin reserved for holding this position group
        /// </summary>
        public static ReservedBuyingPowerForPositionGroup GetReservedBuyingPowerForPositionGroup(
            this IPositionGroupBuyingPowerModel model,
            IPositionGroup positionGroup
            )
        {
            return model.GetReservedBuyingPowerForPositionGroup(
                new ReservedBuyingPowerForPositionGroupParameters(positionGroup)
            );
        }
    }
}
